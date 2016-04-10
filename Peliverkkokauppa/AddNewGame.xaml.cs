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
            Olen onnistunut siirtämään tietoa UWP-sovelluksen, php-scriptin ja mysql tietokannan välillä.
            Enää on varmistettava php-scriptin käyttäminen koulunpalvelimella.



            */

        }
    }
}
