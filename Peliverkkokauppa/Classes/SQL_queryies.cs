using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Newtonsoft.Json;
using Windows.Web;
using System.Net;
using System.Net.Http;

namespace Peliverkkokauppa
{
    class SQL_queryies
    {
        public Dictionary<int, Game> Directory_Games { get; set; }
        public string Status { get; set; }

        /*
        Nämä ovat ohjelman käynnistämisen aikana suoritettavia skriptejä.
        */



        //Send "mysql select query"
        public async void SQL_Query_GetGames()
        {
            
            try
            {

                int GameID;
                string Name;
                string Description;
                float Price;
                string Genre;
                Developer Developer;
                DateTime ReleaseDate;
                Statistics stat = new Statistics();


                string Query = "Select * from Game";

                String[] ResultOfQuery = await GetAndSend(Query);

                //Lasketaan kuinka monta riviä php vastasi ohjelmalle
                int Responses = ResultOfQuery.Count();
                
                //otetaan php errorit pois
                Responses = Responses - 1;

                //tulee sisältämään itse sisällön tiedot esim. [0] -> GameID, [1] -> Name....
                string RLines_content;

                if(Responses <= 0)
                {
                    Status = "Ei tuloksia";
                }
                else
                {
                    //luominen alkaa arrays kerroksesta [1] joten response lukuun on lisättävä 1
                    for (int i = 1; i < Responses + 1; i++)
                    {
                        RLines_content = ResultOfQuery[i];
                        String[] Input = RLines_content.Split('+');

                        GameID = Convert.ToInt16(Input[0]);
                        Name = Convert.ToString(Input[1]);
                        Description = Convert.ToString(Input[2]);
                        Price = Convert.ToInt32(Input[3]);
                        Genre = Convert.ToString(Input[4]);

                        Dictionary<int, MediaFile> ListofFiles = await GetMediaFiles(GameID);
                       


                        Developer = stat.ListOfDevelopers[Convert.ToString(Input[5])];
                        ReleaseDate = Convert.ToDateTime(Input[6]);

                        //[9]is the final that contains data ("DateOfCreation");


                    }
                }

            }
            catch (Exception ex)
            {
                //Ohjelman virheet
                Status = "Virhe: " + ex.Message;
            }
        
        }


        public async Task<Dictionary<int, MediaFile>> GetMediaFiles(int GameID)
        {
            //haetaan mediatiedostot ja luodaan mediafilelist oliot
            Dictionary<int, MediaFile> mediafilelist = new Dictionary<int, MediaFile>();

            //--------Etsitään mediatiedostot----------
            string mediaquery =
                "Select mediafile.MediaID, mediafile.GameID, mediafile.Path From mediafile INNER JOIN game ON " + "game.GameID = mediafile.GameID Having mediafile.GameID = \"" + GameID + "\";";

            string[] Mediafiles = await GetAndSend(mediaquery);

            //Lasketaan kuinka monta riviä php vastasi ohjelmalle
            int MediafileCount = Mediafiles.Count();

            
            //jos on olemassa mediatiedostoja pelille
            
                for (int x = 1; x < MediafileCount; x++)
                {
                    String[] Mediafile_input = Mediafiles[x].Split('+');

                    MediaFile NewMedia = new MediaFile(Convert.ToInt32(Mediafile_input[0]), Mediafile_input[3]);
                mediafilelist.Add(Convert.ToInt32(Mediafile_input[0]), NewMedia);
                }
         

            //-------------------
            return mediafilelist;
        }


        //int = mediaID auto_increment 
        public async Task<String[]> GetAndSend(string Query)
        {
            /*
            use to send queries to sql server

            Task<array> = Response from server
            [0] php errors
            [1 ... n] Content
            */


            //Link to phpfile
            Uri URI = new Uri("http://localhost:8080/valt/php.php");


            //Create and send json files to php script
            Dictionary<string, string> Json = new Dictionary<string, string>();
            Json.Add("query", Query);

            //Convert dictionary to json object: in php POST["query"] refers to "Select * From Customer"
            var testi = JsonConvert.SerializeObject(Json);


            var content = new FormUrlEncodedContent(Json);

            //Create webrequest
            var httprequest = (HttpWebRequest)WebRequest.Create(URI);
            httprequest.ContentType = "application/json";
            httprequest.Method = "POST";

            using (var streamWriter = new StreamWriter(await httprequest.GetRequestStreamAsync()))
            {

                streamWriter.Write(testi);
                streamWriter.Flush();
                streamWriter.Dispose();
            }

            string response_text = "No response";

            var response = (HttpWebResponse)await httprequest.GetResponseAsync();
            Encoding encd = System.Text.Encoding.GetEncoding("utf-8");
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                response_text = result;
                //response_text sisältää php lähettämän vastauksen (echo tai print käsky)
            }

            //erotetaan tulokset
            string[] RLines = response_text.Split(Convert.ToChar(";"));
            //RLines[0] = php errorit.

            return RLines;

        }//End of Getand Send

    }
}
