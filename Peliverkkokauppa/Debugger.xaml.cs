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
    public sealed partial class Debugger : Page
    {
        public Debugger()
        {
            this.InitializeComponent();
            Stat_Screen.Text += "App Current Statistics:" + Environment.NewLine;
            Stat_Screen.Text += "------------------------" + Environment.NewLine;

            
            
            int dev = Statistics.ListOfDevelopers.Count;
            int Games = Statistics.ListOfGames.Count;
            


            Stat_Screen.Text += "Developers Count: " + dev + Environment.NewLine;

            if (dev != 0)
            {
                Stat_Screen.Text += "------------------------" + Environment.NewLine;

                foreach (String name in Statistics.ListOfDevelopers.Keys)
                {
                    Stat_Screen.Text += name + Environment.NewLine;
                }

                Stat_Screen.Text += "------------------------" + Environment.NewLine;

            }


            Stat_Screen.Text += "Game Count: " + Games + Environment.NewLine;

            if (Games != 0)
            {
                Stat_Screen.Text += "------------------------" + Environment.NewLine;

                foreach (Game name in Statistics.ListOfGames.Values)
                {
                    Stat_Screen.Text += "Name: " + name.Name + ", GameID: " + name.GameID + Environment.NewLine;
                }

                Stat_Screen.Text += "------------------------" + Environment.NewLine;

            }
        }

        private void CreateDeveloper_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(CreateDeveloper));
        }

        private void CreateGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewGame));
        }



        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(login1));
        }

        
     

      

      
    }
}
