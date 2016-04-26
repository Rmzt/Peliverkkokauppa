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
            catch (NullReferenceException)
            {
                
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

                    bool error = false;

                    int GameID = Statistics.ListOfGames.Count + 1;
                    GameName = Name_input.Text;

                    if (StringTest(GameName) != true)
                    {
                    error = true;
                    NameError.Text = "Has to be only letters and larger than 0";
                    }
                else
                {
                    NameError.Text = "";
                }

                    Description = Description_input.Text;
                    
                    if(Price_input.Text == "")
                    {
                    error = true;
                    PriceError.Text = "Price cannot be null";
                    }
                    else {
                    PriceError.Text = "";
                    float Prices = Convert.ToInt32(Price_input.Text);

                    if (PriceTest(Price) != true)
                    {
                    error = true;
                    }
                    else
                    {
                        PriceError.Text = "";
                        Price = Prices;
                    }
                }

               

                    if (Genre_input.SelectedValue == null)
                    {
                    error = true;
                    GenreError.Text = "Select genre";
                }
                else
                {
                    GenreError.Text = "";
                    Genre = Convert.ToString(Genre_input.SelectedValue);
                }

                   

                     if (Developer_Combo.SelectedValue == null)
                     {
                    error = true;
                    DeveloperError.Text = "Select developer";
                }
                else
                {
                    DeveloperError.Text = "";
                    Developer = Convert.ToString(Developer_Combo.SelectedValue);
                }

                if(ReleaseDate_input.Date.HasValue != false)
                {
                    ReleaseDate = ReleaseDate_input.Date.Value;
                    ReleaseDateError.Text = "";
                }
                else
                {

                    error = true;
                    ReleaseDateError.Text = "Select release date";

                }

                


                if (error != true)
                    {
                  
                    Game NewGame = new Game(GameID,GameName, Description, Price, Genre, Developer, ReleaseDate,"Assets/coverimg/default.png");
                    NewGame.GameID = GameID;
                    this.Frame.Navigate(typeof(AddNewGamePage2), NewGame);

                    }



            }
                catch (Exception)
                {
                    
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
                return true;
            }
            return false;
        }

        public bool PriceTest(float Price)
        {
            if(Price < 0)
            {
                
                PriceError.Text = "Price has to be larger than 0";
                return false;
            }
            return true;
        }

        

    }

}
