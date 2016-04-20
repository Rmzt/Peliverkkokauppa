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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameSearch : Page
    {
        public List<string> Genres = Statistics.ListOfGenres;
        public String SelectedFilter { get; set; }
        public string DefaultUser = "Not logged in";
        
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


            
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Profiili));
        }

        private void Options_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectedFilter = e.ClickedItem.ToString();
        }
    }
}
