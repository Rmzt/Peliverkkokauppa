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

using MySql.Data.MySqlClient;


namespace Peliverkkokauppa
{
    class SQL_queryies
    {

        public string database = "gamestore";
        public string user = "root";
        public string password = "";
        public string path = "Localhost";

        public MySqlConnection ConnectToSQL()
        {
            //yhdistää sql-palvelimeen
            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);


            string mySQLConn = "Server=" + path + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password +";SslMode=None;";
            MySqlConnection db = new MySqlConnection(mySQLConn);

            db.Open();
            return db;
        }

        public MySqlDataReader Query(string query)
        {
            //Suorita SQL-komento ja hae kyselyn tulokset;
            MySqlConnection Conn = ConnectToSQL();
            MySqlCommand command = new MySqlCommand(query, Conn);
            MySqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void ReadGamesFromDatabase()
        {
            //Haetaan pelit tietokannasta
            try {
                MySqlDataReader reader = Query("Select * from game");

                //Lukee kaikki tiedot, laittaa listan ja linkittää ne dictionary rakenteeseen, avaimena gameid
                while (reader.Read())
                {
                    //tulokset laitetaan array objectiin
                    object[] obj = new object[7];
                    reader.GetValues(obj);

                    int gameID = Convert.ToInt32(obj[0]);
                    string name = Convert.ToString(obj[1]);
                    string description = Convert.ToString(obj[2]);
                    float price = Convert.ToInt32(obj[3]);
                    string genre = Convert.ToString(obj[4]);
                    string developer = Convert.ToString(obj[5]);
                    DateTimeOffset releaseDate = Convert.ToDateTime(obj[6]);


                    Game new_game = new Game(gameID, name,description,price,genre,"",developer,releaseDate);
                    //Haetaan mediatiedostot tietokannasta ja liitetään peliin
                    new_game.MediaFiles = GetMediafiles(gameID);


                    //Haetaan arvostelut tietokannasta ja liitetään peliin      
                    new_game.Reviews = GetReview(gameID);

                    Statistics.ListOfGames.Add(gameID, new_game);


                }




            }
            catch(Exception ex)
            {

            }
        }






        public Dictionary<int,MediaFile> GetMediafiles(int id)
        {

            Dictionary<int, MediaFile> Medialist = new Dictionary<int, MediaFile>();

            try
            {
                MySqlDataReader reader = Query("Select * from mediafile where GameID = " +id + ";");
              

                //Lukee kaikki tiedot, laittaa listan ja linkittää ne dictionary rakenteeseen, avaimena gameid
                while (reader.Read())
                {

                    //tulokset laitetaan array objectiin
                    object[] obj = new object[3];
                    reader.GetValues(obj);

                    int MediaID = Convert.ToInt32(obj[0]);
                    string Path = Convert.ToString(obj[2]);

                    Medialist.Add(MediaID,new MediaFile(MediaID, Path));
                    
                    
                }

                
            }
            catch (Exception ex)
            {

            }

            return Medialist;
        }

        public Dictionary<int, Review> GetReview(int id)
        {

            Dictionary<int, Review> Reviews = new Dictionary<int, Review>();

            try
            {
                MySqlDataReader reader = Query("Select * from review where GameID = " + id + ";");


                //Lukee kaikki tiedot, laittaa listan ja linkittää ne dictionary rakenteeseen, avaimena gameid
                while (reader.Read())
                {

                    //tulokset laitetaan array objectiin
                    object[] obj = new object[3];
                    reader.GetValues(obj);

                    int Reviewid = Convert.ToInt32(obj[0]);
                    string Username = Convert.ToString(obj[1]);
                    int Stars = Convert.ToInt32(obj[2]);


                    Reviews.Add(Reviewid, new Review(Reviewid,Username,Stars));


                }


            }
            catch (Exception ex)
            {

            }

            return Reviews;
        }

    }
}
