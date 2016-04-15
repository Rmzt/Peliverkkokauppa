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

        public Game New_Game { get; set; }

        public AddNewGamePage2()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Game)
            {
                New_Game = (Game)e.Parameter;
               
                Description_input.Text = New_Game.Description;

                Game_info.Text += "GameID: " + New_Game.GameID + Environment.NewLine;
                Game_info.Text += "Name: " + New_Game.Name + Environment.NewLine;
                Game_info.Text += "Genre: " + New_Game.Genre + Environment.NewLine;
                Game_info.Text += "Developer: " + New_Game.Developer + Environment.NewLine;
                Game_info.Text += "Price: " + New_Game.Price + Environment.NewLine;
                Game_info.Text += "ReleaseDate: " + New_Game.ReleaseDate + Environment.NewLine;
                

            }

            base.OnNavigatedTo(e);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Debugger));

            SQL_queryies SQL = new SQL_queryies();
            SQL.SQL_INSERT_GAME(New_Game);



        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewGame),New_Game);
        }
    }
}
