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
        private Statistics Statistics { get; set; }
        public string Default { get; set; }



        public AddNewGame()
        {

            
            //------Make listbox select default as developer---------------- 
            this.InitializeComponent();

            try {
                int count = Statistics.ListOfDevelopers.Count;

                listBox.ItemsSource = Statistics.ListOfDevelopers.Keys;
            }
            catch(NullReferenceException Error)
            {
                Errorbox.Text = "Nullreference: " + Error.Message;
            }

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
                Errorbox.Text = ex.Message;
            }



            Statistics Statistics = new Statistics();
            //int GameID = Statistics.ListOfGames.Count();
            int GameID = 1;
            Game NewGame = new Game(GameID, GameName, Description, Price, Genre, "", Developer, ReleaseDate);
            Statistics.ListOfGames.Add(GameID, NewGame);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Developer)
            {
                Developer dev = (Developer)e.Parameter;
                Default = dev.Name;

            }


            base.OnNavigatedTo(e);
        }

    }

}
