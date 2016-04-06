using System;
using System.Resources;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.Text;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewGame : Page
    {


        //GameID automaattisesti luotu?
        //Pelien määrän mukaan?

        public string GameName { get; set; }
        public string Description { get; set; }
        public float Price
        {
            get; set;
        }

        public string Genre { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        private Statistics Stat { get; set; }




        public AddNewGame()
        {
            this.InitializeComponent();
            //Luodaan testikehittäjiä
            Developer dev1 = new Developer("Dev1", "Ad1", "description", "Email@email.com");
            Developer dev2 = new Developer("Dev2", "Ad2", "description", "Email@email.com");
            Developer dev3 = new Developer("Dev3", "Ad3", "description", "Email@email.com");
            Developer dev4 = new Developer("Dev4", "Ad4", "description", "Email@email.com");

            List<Developer> developers = new List<Peliverkkokauppa.Developer>();
            developers.Add(dev1);
            developers.Add(dev2);
            developers.Add(dev3);
            developers.Add(dev4);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            //keskeneräinen
            try
            {
                GameName = Name_input.Text;
                Description = Description_input.Text;
                Price = Convert.ToInt32(Price_input.Text);
                Genre = Genre_input.Text;
                //ReleaseDate = Convert.ToDateTime(ReleaseDate_input.Date.Value);
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message;
            }



            Statistics Stat = new Statistics();
            //int GameID = Stat.ListOfGames.Count();
            int GameID = 1;
            Game NewGame = new Game(GameID, GameName, Description, Price, Genre, "", Developer, ReleaseDate);

                /* 
                 XmlDocument GamesDoc = new XmlDocument();
                 XmlNode rootNode = GamesDoc.CreateElement("Games");
                 GamesDoc.AppendChild(rootNode);

                 //luodaan xml-peliolio
                 XmlNode gameNode = GamesDoc.CreateElement("Game");

                 //Määritetään uudelle pelioliolle ominaisuuksia
                 XmlAttribute NameAttribute = GamesDoc.CreateAttribute("Name");
                 XmlAttribute PriceAttribute = GamesDoc.CreateAttribute("Price");
                 XmlAttribute GenreAttribute = GamesDoc.CreateAttribute("Genre");
                 XmlAttribute ReleaseDateAttribute = GamesDoc.CreateAttribute("ReleaseDate");
                 XmlAttribute DescriptionAttribute = GamesDoc.CreateAttribute("Descripton");

                 XmlAttribute DeveloperAttribute = GamesDoc.CreateAttribute("Developer");
                 XmlAttribute GameIDAttribute = GamesDoc.CreateAttribute("GameID");

                 //Lisätään ominaisuuksiin niiden arvot

                 NameAttribute.Value = GameName;
                 PriceAttribute.Value = Convert.ToString(Price);
                 GenreAttribute.Value = Genre;
                 ReleaseDateAttribute.Value = Convert.ToString(ReleaseDate);
                 DescriptionAttribute.Value = Description;
                 GameIDAttribute.Value = Convert.ToString(GameID);
                 DeveloperAttribute.Value = "testi";


                 gameNode.Attributes.Append(NameAttribute);
                 gameNode.Attributes.Append(PriceAttribute);
                 gameNode.Attributes.Append(GenreAttribute);
                 gameNode.Attributes.Append(ReleaseDateAttribute);
                 gameNode.Attributes.Append(DescriptionAttribute);
                 gameNode.Attributes.Append(GameIDAttribute);
                 gameNode.Attributes.Append(DeveloperAttribute);

                 rootNode.AppendChild(gameNode);

                 byte[] data = Encoding.ASCII.GetBytes("test.xml");
                 GamesDoc.Save(dat);
                 */
                var serializer = new XmlSerializer(typeof(Game));
                var path = "D:'\'K1967'\'sfm.xml";

                System.IO.FileStream file = System.IO.File.Create(path);
                serializer.Serialize(file, NewGame);
                
                /*
                //Jos käyttäjä ei ole tehnyt virheitä
                try
                {
                    //Luodaan kirjoittaja

                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Game));

                    //polku
                    string path = Convert.ToString(Directory.GetCurrentDirectory()) + "/testi.xml";
                    System.IO.FileStream file = System.IO.File.Create(path);

                    writer.Serialize(file, NewGame);
                }
                catch (Exception ax)
                {
                    Description_input.Text = ax.Message;
                }
            */
        }
    }
}
