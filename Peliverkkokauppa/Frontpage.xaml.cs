using System;
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
using System.Diagnostics;
using System.Collections;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Data.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

       

    public sealed partial class Frontpage : Page
    {
        public static Dictionary<int,Game> Lista = Statistics.ListOfGames;
        public List<Game> Listat { get; set; }

        public Frontpage()
        {
            Listat = new List<Game>();

            foreach (Game game in Lista.Values)
            {
                Listat.Add(game);
            }

            try
            {
                this.InitializeComponent();
                Username_output.Text = Statistics.LoggedInUser.Username;
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(login1));
        }

        private void Peli1_Click(object sender, RoutedEventArgs e)
        {
            //Game testgame = new Game { };
            //testgame = ListOfGames[1];
            this.Frame.Navigate(typeof(GamePage), Statistics.ListOfGames[1]);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Profiili));
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Image image = e.OriginalSource as Image;
            if (image != null)
            {
                
            }
        }

        private void New_Games_ItemClick(object sender, ItemClickEventArgs e)
        {
            //siirtää asiakkaan pelisivulle
            Game peli = (Game)e.ClickedItem;
            this.Frame.Navigate(typeof(GamePage), peli);
        }

        private void Game_By_Genre_Tapped(object sender, TappedRoutedEventArgs e)
        {
           // this.Frame.Navigate(typeof(SearchPage));
        }

        private void Profile2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Profiili));
        }

        private void Selailu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameSearch));
        }
    }

    }

