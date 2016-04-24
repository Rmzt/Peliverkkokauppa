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

        //Binding element
        public string TotalScore { get; set; }
        public float TrueScoreTotal { get; set; }

        private float price { get; set; }
        //Scorea ei varmaan tarvitse tähän lisätä kun se voidaan laskea Reviews dictionarysta aina

        public Game(string name, string description, float price, string genre, string developer, DateTimeOffset releaseDate)
        {
            //tämä on vanha konstuktori, alla uusi
            Name = name;
            Description = description;
            Price = price;
            Genre = genre;
            Developer = developer;
            ReleaseDate = releaseDate;

        
            MediaFiles = new Dictionary<int, MediaFile>();
            Reviews = new Dictionary<int, Review>();

        }

        public Game(int gameID, string name, string description, float price, string genre, string developer, DateTimeOffset releaseDate, string coverimg)
        {
            GameID = gameID;
            Name = name;
            Description = description;
            Price = price;
            Genre = genre;
            Developer = developer;
            ReleaseDate = releaseDate;
            Coverimg = coverimg;

            MediaFiles = new Dictionary<int, MediaFile>();
            Reviews = new Dictionary<int, Review>();
            
        }

        public string GetScore()
        {
            float i = 0;
            int divine = 0;

            if (Reviews.Count == 0)
            {
                return "No reviews";

            } else
            {
                foreach(Review rew in Reviews.Values)
                {
                    i += rew.Stars;
                    divine++; 
                }
            }
            i = i / divine;


            return string.Format("{0:0.00}", i);
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
            foreach(Game game in Statistics.ListOfGames.Values)
            {
                if(GameID == game.GameID)
                {
                    game.Reviews.Add(i, t);
                }
            }
            
        }

    }
}
