using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Reflection;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameSearch : Page
    {
        public List<string> Genres = Statistics.ListOfGenres;
        public List<Game> GameList { get; set; }
        public Dictionary<int, Game> DictionaryOfGames = Statistics.ListOfGames;

        
        public ObservableCollection<Game> List = new ObservableCollection<Game>();
        
        public PropertyInfo SelectedFilter { get; set; }
        public string DefaultUser = "Not logged in";

        public bool First = true;


        public bool GenreFilterIsSet = false;
        public bool OtherFilterIsSet = false;








        public GameSearch()
        {
            this.InitializeComponent();

            OtherFilter.Items.Add("No filter");
            OtherFilter.Items.Add("Lowest price");
            OtherFilter.Items.Add("Highest price");
            OtherFilter.Items.Add("Biggest score");
            OtherFilter.Items.Add("Lowest score");
            OtherFilter.Items.Add("Name accending");
            OtherFilter.Items.Add("Name decending");




            if (User.Text.Length != 0)
            {
                User.Text = Statistics.LoggedInUser.Username;
            } else
            {
                User.Text = DefaultUser;
            }

            float average = 0;

            if (First == true)
            {
                try
                {
                    GameList = DictionaryOfGames.Values.ToList();
                    foreach (Game game in GameList)
                    {
                        
                        foreach(Review rew in game.Reviews.Values)
                        {
                            average += rew.Stars;
                        }

                        average = average / game.Reviews.Values.Count;

                        if(float.IsNaN(average) == true)
                        {
                            game.TotalScore = "No reviews";
                            game.TrueScoreTotal = -1;
                        }
                        else
                        {
                            game.TotalScore = Convert.ToString(average);
                            game.TrueScoreTotal = average;
                        }

                        List.Add(game);

                        average = 0;

                    }

                }
                catch (Exception)
                {

                }
                
                First = false;
            }
            else
            {
                Output.DataContextChanged += (s, e) => Bindings.Update();
            }


        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Statistics stat = new Statistics();
            stat.Logout();
            this.Frame.Navigate(typeof(login1));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (Statistics.IsCustomer == true)
            {
                this.Frame.Navigate(typeof(Profiili));

            }
            else
            {
                this.Frame.Navigate(typeof(EmployeePage));
            }
        }

        private void Options_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenreFilterIsSet = true;

            
            List.Clear();
            foreach (Game game in GameList)
            {

                if(game.Genre == e.ClickedItem.ToString())
                {
                    List.Add(game);    
                }

            }
            List<Game> Games = List.ToList();

            if (OtherFilterIsSet == true)
            {
                OrderList(Games, OtherFilter.SelectedValue.ToString());
            }


        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            List.Clear();


            foreach (Game game in GameList)
            {
                List.Add(game);
            }

            if(OtherFilterIsSet == true)
            {
                OrderList(List.ToList(), OtherFilter.SelectedValue.ToString());
            }


        }

        private void Output_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem.GetType() == typeof(Game))
            {
                this.Frame.Navigate(typeof(GamePage), e.ClickedItem);
            }
        }

        private void ResetAllFilters_Click(object sender, RoutedEventArgs e)
        {
            List.Clear();
            foreach(Game game in GameList)
            {
                List.Add(game);
            }

            OtherFilter.SelectedIndex = 0;
        }

        private void OrderList(List<Game> lista, string otherfilter)
        {
            List<Game> Sortedlist = new List<Game>();

            switch (otherfilter)
            {

                case "No filter":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            List.Add(game);
                        }

                        break;
                    }

                case "Lowest price":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            Sortedlist.Add(game);
                        }

                        Sortedlist = Sortedlist.OrderBy(o => o.Price).ToList();

                        foreach (Game game in Sortedlist)
                        {
                            List.Add(game);
                        }

                        break;
                    }


                case "Highest price":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            Sortedlist.Add(game);
                        }
                        Sortedlist = Sortedlist.OrderByDescending(o => o.Price).ToList();

                        foreach (Game game in Sortedlist)
                        {
                            List.Add(game);
                        }

                        break;
                    }
                case "Biggest score":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            Sortedlist.Add(game);
                        }

                        Sortedlist = Sortedlist.OrderByDescending(o => o.TrueScoreTotal).ToList();

                        foreach (Game game in Sortedlist)
                        {
                            List.Add(game);
                        }

                        break;
                    }
                case "Lowest score":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            Sortedlist.Add(game);
                        }

                        Sortedlist = Sortedlist.OrderBy(o => o.TrueScoreTotal).ToList();

                        foreach (Game game in Sortedlist)
                        {
                            List.Add(game);
                        }
                        break;
                    }

                case "Name accending":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            Sortedlist.Add(game);
                        }

                        Sortedlist = Sortedlist.OrderBy(o => o.Name).ToList();

                        foreach (Game game in Sortedlist)
                        {
                            List.Add(game);
                        }
                        break;
                    }

                case "Name decending":
                    {
                        List.Clear();
                        foreach (Game game in lista)
                        {
                            Sortedlist.Add(game);
                        }

                        Sortedlist = Sortedlist.OrderByDescending(o => o.Name).ToList();

                        foreach (Game game in Sortedlist)
                        {
                            List.Add(game);
                        }

                        break;
                    }

            }
            


        }


        private void OtherFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Haetaan lista, jota lajitellaan.
            //Jos genre on valittu, niin genren valitsema lajitellaan

            /*
            1. Tarkistetaan onko Genre valittu
            2. Haetaan Genre valitsema Lista
            3. Lajitellaan Lista

            Jos genre muuttuu
            1. Haetaan uusi lista
            2. Lajitellaan

            Jos lajitteluperuste muuttuu
            1. Käytetään olemassa olevaa genreä.

            */

            string filter = OtherFilter.SelectedValue.ToString();
            List<Game> InputList = List.ToList();
            List<Game> OutputList = new List<Game>();

            OtherFilterIsSet = true;
            OrderList(InputList,filter);
            
                        


            }

        }
 }
    
