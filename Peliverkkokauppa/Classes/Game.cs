using System;
using System.IO;
using Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    public class Game
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price
        {
            get { return price; }
            set { if (value >= 0.0f) price = value; else price = 0.0f; }
        }
        public string Genre { get; set; }
        public string Coverimg { get; set; }
        public string Developer { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public Dictionary<int, MediaFile> MediaFiles { get; set; }
        public Dictionary<int, Review> Reviews { get; set; }

        public string ImageLocation {
            get
            {
                return ImageLocation;
            }
            set
            {
            }
        }

        private float price { get; set; }
        //Scorea ei varmaan tarvitse tähän lisätä kun se voidaan laskea Reviews dictionarysta aina


        public Game(int gameID, string name, string description, float price, string genre, string coverimg, string developer, DateTimeOffset releaseDate)
        {
            GameID = gameID;
            Name = name;
            Description = description;
            Price = price;
            Genre = genre;
            Coverimg = coverimg;
            Developer = developer;
            ReleaseDate = releaseDate;

            MediaFiles = new Dictionary<int, MediaFile>();
            Reviews = new Dictionary<int, Review>();

            ImageLocation = new Uri(coverimg).AbsolutePath;
            
        }

        public Game()
        {
            MediaFiles = new Dictionary<int, MediaFile>();
            Reviews = new Dictionary<int, Review>();
        }

        public void RemoveMediaFile(int i)
        {
            if (MediaFiles.ContainsKey(i))
            {
                MediaFiles.Remove(i);
            }
        }

        public void AddMediaFile(int i, MediaFile t)
        {
            MediaFiles.Add(i, t);
        }

        public void RemoveReview(int i)
        {
            if (Reviews.ContainsKey(i))
            {
                Reviews.Remove(i);
            }
        }

        public void AddReview(int i, Review t)
        {
            Reviews.Add(i, t);

        }

        

        public void CreateDummyGames(int times)
        {
            //Luodaan testidataa



            int GameID = Statistics.ListOfGames.Count + 1;


            for (int i = 0; i < times; i++)
            {

                Game new_game = new Game(GameID, Convert.ToString("Peli " + GameID), "Pelin heino kuvaus", 55 + GameID, "Kauhu", "PathX", "Kehittaja" + GameID, DateTimeOffset.Now);
                GameID = GameID + i;
                Statistics.ListOfGames.Add(GameID,new_game);
                
            }
        }


    }
}
