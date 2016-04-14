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
    public sealed partial class AddNewGamePage2 : Page
    {
        public AddNewGamePage2()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Game)
            {
                Game game = (Game)e.Parameter;
                Description_input.Text = game.Description;

                Game_info.Text += "GameID: " + game.GameID + Environment.NewLine;
                Game_info.Text += "Name: " + game.Name + Environment.NewLine;
                Game_info.Text += "Genre: " + game.Genre + Environment.NewLine;
                Game_info.Text += "Developer: " + game.Developer + Environment.NewLine;
                Game_info.Text += "Price: " + game.Price + Environment.NewLine;
                Game_info.Text += "ReleaseDate: " + game.ReleaseDate + Environment.NewLine;
                

            }

            base.OnNavigatedTo(e);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Debugger));
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
