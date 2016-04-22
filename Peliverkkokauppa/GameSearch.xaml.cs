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

        public GameSearch()
        {
            this.InitializeComponent();
            if(User.Text.Length != 0)
            {
                User.Text = Statistics.LoggedInUser.Username;
            } else
            {
                User.Text = DefaultUser;
            }

            
            if(First == true)
            {
                GameList = DictionaryOfGames.Values.ToList();
                foreach(Game game in GameList)
                {
                    List.Add(game);
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
            List.Clear();
            foreach (Game game in GameList)
            {
                if(game.Genre == e.ClickedItem.ToString())
                {
                    List.Add(game);
                    
                }

            }

        
            
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            List.Clear();
            foreach(Game game in GameList)
            {
                List.Add(game);
            }
        }

        private void Output_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem.GetType() == typeof(Game))
            {
                this.Frame.Navigate(typeof(GamePage), e.ClickedItem);
            }
        }



        /*
        //Järjestellään valinnan mukaan...
            SelectedFilter = typeof(Game).GetProperty(e.ClickedItem.ToString());
            SortedList = SortedList.OrderBy(o => SelectedFilter).ToList();
        */
    }
}
