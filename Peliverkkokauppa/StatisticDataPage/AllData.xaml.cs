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
    public sealed partial class AllData : Page
    {
        public List<Game> Games = new List<Game>();
        public List<Developer> Developer = new List<Developer>();
        public bool Isconnected { get; set; }



        public AllData()
        {
            GetDeveloper();
            GetGames();
            if(Statistics.LoggedInUser != null)
            {
                Isconnected = true;
            } 
            this.InitializeComponent();
            
            if(Isconnected == true)
            {
                ConBox.Text = "Connected user";
            }
            else
            {
                ConBox.Text = "User not found";
            }


            if (Games.Count != 0) { 
            foreach(Game game in Games)
            {
                Games_box.Text += "---Game" + game.Name + "-------" + Environment.NewLine;
                Games_box.Text += Convert.ToString(game.GameID) + Environment.NewLine;
                Games_box.Text += game.Name + Environment.NewLine;
                Games_box.Text += Convert.ToString(game.Price) + Environment.NewLine;
                Games_box.Text += game.Description + Environment.NewLine;
                Games_box.Text += game.Developer + Environment.NewLine;
                Games_box.Text += game.Genre + Environment.NewLine;
                Games_box.Text += Convert.ToString(game.ReleaseDate) + Environment.NewLine;
                Games_box.Text += game.Coverimg + Environment.NewLine;
                Games_box.Text += "-------------------" + Environment.NewLine;
            }
                Games_box.Text += "End of stream";
            } else
            {
                Games_box.Text = "No games found";
            }

            if (Developer.Count != 0)
            {
                foreach (Developer dev in Developer)
                {
                    Games_box.Text += "---dev" + dev.Name + "-------" + Environment.NewLine;
                    Games_box.Text += dev.Name + Environment.NewLine; ;
                    Games_box.Text += dev.Description + Environment.NewLine; ;
                    Games_box.Text += dev.Email + Environment.NewLine;
                    Games_box.Text += dev.Address + Environment.NewLine;
                    Games_box.Text += "-------------------" + Environment.NewLine;
                }
                Games_box.Text += "End of stream";
            }
            else
            {
                Games_box.Text = "No devs found";
            }

        }



        public void GetDeveloper()
        {
            try
            {
                foreach(Developer dev in Statistics.ListOfDevelopers.Values)
                {
                    Developer.Add(dev);
                }
            }
            catch (Exception)
            {

            }
        }

        public void GetGames()
        {
            try
            {
            foreach(Game game in Statistics.ListOfGames.Values)
            {
                Games.Add(game);
            }
            }
            catch (Exception)
            {

            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
