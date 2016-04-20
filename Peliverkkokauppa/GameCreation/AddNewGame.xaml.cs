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
        public List<string> info = new List<string>();
        public string GameName { get; set; }
        public string Description { get; set; }
        public float Price
        {
            get; set;
        }

        public string Genre { get; set; }
        public string Developer { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }


        private Statistics Statistics { get; set; }
        public string Default { get; set; }

        //Error laskee kuinka monta erroria on olemassa. Kun erroreita on 0 niin voidaan siirtyä eteenpäin.
        
        public Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();
        public AddNewGame()
        {

            
            //------Make listbox select default as developer---------------- 
            this.InitializeComponent();

            try {
                
                foreach(String name in Statistics.ListOfDevelopers.Keys)
                {
                    Developer_Combo.Items.Add(name);
                }

                foreach (String Genre in Statistics.ListOfGenres)
                {
                    Genre_input.Items.Add(Genre);
                }


                if(Developer_Combo.Items.Count == 0)
                {
                    Developer_Combo.Items.Add("No developers defined");
                }

                if (Genre_input.Items.Count == 0)
                {
                    Genre_input.Items.Add("No genres defined");
                }


            }
            catch (NullReferenceException Error)
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
         
                try
                {
                    int GameID = Statistics.ListOfGames.Count + 1;
                    GameName = Name_input.Text;
                    Description = Description_input.Text;
                    Price = Convert.ToInt32(Price_input.Text);
                    Genre = Convert.ToString(Genre_input.SelectedValue);
                    Developer = Convert.ToString(Developer_Combo.SelectedValue);
                    ReleaseDate = ReleaseDate_input.Date.Value;


                    Game NewGame = new Game(GameName, Description, Price, Genre, Developer, ReleaseDate);
                    NewGame.GameID = GameID;
                    
                    this.Frame.Navigate(typeof(AddNewGamePage2), NewGame);

                }
                catch (Exception ex)
                {
                    Errorbox.Text = ex.Message;
                }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Jos sivulle siirrytään, joko kehittäjän sivulta tai pelinluomisen toiselta sivulta.

            if (e.Parameter is Developer)
            {
                Developer dev = (Developer)e.Parameter;
                Developer = dev.Name;
                Developer_Combo.SelectedValue = Developer;
                
            }

            if (e.Parameter is Game)
            {
                
                Game Game_Create = (Game)e.Parameter;
                Name_input.Text = Game_Create.Name;
                Price_input.Text = Convert.ToString(Game_Create.Price);
                Genre_input.SelectedValue = Game_Create.Genre;
                Developer_Combo.SelectedValue = Game_Create.Developer;
                ReleaseDate_input.Date = Game_Create.ReleaseDate.Date;
                Description_input.Text = Game_Create.Description;
               
            }


            base.OnNavigatedTo(e);
        }

        private void AddMediafiles_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }

        private void CoverImg_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }

        public bool StringTest(string name)
        {
            int i = 0;
            if(Name_input.Text.Length > 0 && int.TryParse(Name_input.Text, out i) != true)
            {
                InfoBox.Text = "";
                return true;
            }
            InfoBox.Text = "Name has to be only letters and not null";
            return false;
        }

        public bool PriceTest(int Price)
        {
            if(Price < 0)
            {
                InfoBox.Text = "Price has to be larger than 0";
                return false;
            }
            return true;
        }

        private void Name_input_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            StringTest(Name_input.Text);
        }

        private void Name_input_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            StringTest(Name_input.Text);
        }

    }

}
