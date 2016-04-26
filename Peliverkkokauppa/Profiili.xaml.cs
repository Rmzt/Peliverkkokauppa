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
    public sealed partial class Profiili : Page
    {

        public string username = Statistics.LoggedInUser.Username;
        public Statistics stat { get; set; }
        public List<Game> Game = new List<Game>();

        public Profiili()
        {
            this.InitializeComponent();
            
            try { 
            Game.AddRange(Statistics.LoggedInUser.OwnedGame.Values);
            Username.Text = Statistics.LoggedInUser.Username;
            Email.Text = Statistics.LoggedInUser.Email;
            Firstname.Text = Statistics.LoggedInUser.Firstname;
            Surname.Text = Statistics.LoggedInUser.Lastname;
            Address.Text = Statistics.LoggedInUser.Address;
            Number.Text = Statistics.LoggedInUser.Phonenumber;
            AccountCreated.Text = Statistics.LoggedInUser.AccountCreated.Date.ToString();

            if (Statistics.LoggedInUser.Username != null)
            {
                Username.Text = username;
            }
            else
            {

            }


            } catch(ArgumentNullException)
            {
                Username.Text = "No user logged in";
            }

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Statistics stat = new Statistics();
            stat.Logout();
            this.Frame.Navigate(typeof(login1));

        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage), e.ClickedItem);
        }
    }
}
