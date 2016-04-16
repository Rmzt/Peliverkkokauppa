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
    public class SQL_queryies
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

            return db;
        }

        public bool NoReturnQuery(string query)
        {
            //Suorita sql-komento. Vastaa kyllä, jos onnistui
            try {
                MySqlConnection Conn = ConnectToSQL();
                Conn.Open();
                MySqlCommand command = new MySqlCommand(query, Conn);

                MySqlDataReader response = command.ExecuteReader();
                response.Read();

                return true;

            }catch(MySqlException)
            {
                return false;
            }

        }

        public MySqlDataReader Query(string query)
        {
        
            //Suorita SQL-komento ja hae kyselyn tulokset;
            MySqlConnection Conn = ConnectToSQL();
            Conn.Open();
            MySqlCommand command = new MySqlCommand(query, Conn);
            MySqlDataReader reader = command.ExecuteReader();
            
            return reader;
        }

        public bool TestConnection()
        {
            MySqlConnection Conn = ConnectToSQL();
            try {
                Conn.Open();
                return true;
            }
            catch(MySqlException)
            {
                return false;
            }
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
                    string developer = Convert.ToString(obj[4]);
                    DateTimeOffset releaseDate = Convert.ToDateTime(obj[5]);
                    string genre = Convert.ToString(obj[6]);


                    Game new_game = new Game(gameID, name,description,price,genre,developer,releaseDate);

                    //Tarkistetaan onko peli olemassa jo "Statistics" -listassa
                    bool existsInApp = Statistics.ListOfGames.ContainsKey(new_game.GameID);

                    if (existsInApp != true)
                    {

                        //Haetaan mediatiedostot tietokannasta ja liitetään peliin
                        new_game.MediaFiles = GetMediafiles(gameID);


                        //Haetaan arvostelut tietokannasta ja liitetään peliin      
                        new_game.Reviews = GetReview(gameID);

                        Statistics.ListOfGames.Add(gameID, new_game);
                    }

                }

            }
            catch(Exception e)
            {
                string x = e.Message;
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
            catch (Exception)  { }
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
            catch (Exception)
            {
            }

            return Reviews;
        }

        public void GetDevelopers()
        {
            MySqlDataReader reader = Query("Select * from developer");
            
            while (reader.Read())
            {
                //tulokset laitetaan array objectiin
                object[] obj = new object[4];
                reader.GetValues(obj);

                string name = Convert.ToString(obj[0]);
                string address = Convert.ToString(obj[1]);
                string description = Convert.ToString(obj[2]);
                string email = Convert.ToString(obj[3]);

                Developer newDeveloper = new Developer(name, address, description, email);
                
                //Tarkistetaan onko peli olemassa jo "Statistics" -listassa
                bool existsInApp = Statistics.ListOfDevelopers.ContainsKey(name);

                if (existsInApp != true)
                {
                    Statistics.ListOfDevelopers.Add(name,newDeveloper);
                }
            }
            
        }

        public void LoadOnStart()
        {
            GetGenre();
            GetDevelopers();
            ReadGamesFromDatabase();

        }

        public void GetGenre()
        {
            MySqlDataReader reader = Query("Select * from genre");

            while (reader.Read())
            {
                //tulokset laitetaan array objectiin
                string genre = reader.GetString(0);



                //Tarkistetaan onko peli olemassa jo "Statistics" -listassa
                bool existsInApp = Statistics.ListOfGenres.Contains(genre);
                if (existsInApp != true)
                {
                    Statistics.ListOfGenres.Add(genre);
                }
            }
        }

        public void SQL_INSERT_GAME(Game game)
        {
            DateTime date = game.ReleaseDate.Date;
            string[] dateformated = date.GetDateTimeFormats(Convert.ToChar("u"));

            string Insert_part = String.Format("INSERT INTO game(GameID,Name,Description,Price,Developer,ReleaseDate,Genre) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", game.GameID, game.Name, game.Description, game.Price, game.Developer, dateformated[0], game.Genre);
            NoReturnQuery(Insert_part);

            foreach (MediaFile file in game.MediaFiles.Values)
            {

                Insert_part = String.Format("INSERT INTO mediafile(GameID, Path) VALUES('{0}','{1}')",game.GameID,file.Path);
                NoReturnQuery(Insert_part);
            }

            foreach (Review review in game.Reviews.Values)
            {
                NoReturnQuery("INSERT INTO review(ReviewID,Username,Stars,GameID)" +
                    " VALUES(" + review.ReviewID + "," + review.Username + "," + review.Stars + "," + game.GameID +
                    ");");
                Insert_part = String.Format("INSERT INTO mediafile(Username,Stars,GameID) VALUES('{0}','{1}','{2}')", review.Username,review.Stars,game.GameID);
                NoReturnQuery(Insert_part);

            }

            Statistics.ListOfGames.Add(game.GameID,game);




        }

        public string CoverImg(int GameID)
        {
            MySqlDataReader Reader = Query(String.Format("Select Path From mediafile where GameID = {0};", GameID));
            while (Reader.Read())
            {
                string[] result = new string[1];
                return result[0];
            }
            return "null";
        }

    }
}
