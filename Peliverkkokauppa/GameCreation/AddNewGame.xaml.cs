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
        public int Error = 0;
        public AddNewGame()
        {

            
            //------Make listbox select default as developer---------------- 
            this.InitializeComponent();

            try {
                int count = Statistics.ListOfDevelopers.Count;
                
                foreach(String name in Statistics.ListOfDevelopers.Keys)
                {
                    Developer_Combo.Items.Add(name);
                }

                foreach (String Genre in Statistics.ListOfGenres)
                {
                    Genre_input.Items.Add(Genre);
                }


                //listBox.ItemsSource = Statistics.ListOfDevelopers.Keys;
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
            if (Error == 0)
            {

                Developer = Convert.ToString(Developer_Combo.SelectedValue);

                try
                {
                    int ID = Statistics.ListOfGames.Count;
                    int GameID;

                    if (ID == 0)
                    {
                        GameID = 1;
                    }
                    else
                    {
                        GameID = ID + 1;
                    }

                    GameName = Name_input.Text;
                    Description = Description_input.Text;
                    Price = Convert.ToInt32(Price_input.Text);
                    Genre = Convert.ToString(Genre_input.SelectedValue);


                    ReleaseDate = ReleaseDate_input.Date.Value;
                    Game NewGame = new Game(GameID, GameName, Description, Price, Genre, Developer, ReleaseDate);

                    this.Frame.Navigate(typeof(AddNewGamePage2), NewGame);




                }
                catch (Exception ex)
                {
                    Errorbox.Text = ex.Message;
                }

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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
               
                //Myös. palvelin valikko?, errorloki
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

        /*
        private void Price_input_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            try { 
                if(Convert.ToDouble(Price_input.Text) < 0)
                {
                    //Errorbox.Text = "Price is lower than 0";
                    if (!ErrorDictionary.ContainsKey("Price"))
                    {
                        ErrorDictionary.Add("Price", "Price is lower than 0");
                    }
                }
            }
            catch (FormatException) { }
        }

        private void Genre_input_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Genre_input.SelectedValue.ToString() == "")
            {
                if (!ErrorDictionary.ContainsKey("Genre"))
                {
                    ErrorDictionary.Add("Genre", "Select genre");
                }
                
            }
        }



        private void Developer_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Developer_Combo.SelectedValue.ToString() == "")
            {
                if (!ErrorDictionary.ContainsKey("Developer"))
                {
                    ErrorDictionary.Add("Developer", "Select developer");
                }
             
            }
            
        }




        private void Name_input_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Output_name = Name_input.Text;

            if (Output_name.Length <= 3)
            {
                if (!ErrorDictionary.ContainsKey("Name"))
                {
                    ErrorDictionary.Add("Name", "Name has to be longer than 3 letters");
                }
            }
            else
            {
                Errorbox.Text = "";
            }
        }


        public void InsertIfContained
        {
            //Lisää ErrorDictionaryyn, jos sitä ei vielä ole lisätty.
        }
        */
    }

}
