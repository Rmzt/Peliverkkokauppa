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
            Stat_Screen.Text += "Game Count: " + Games + Environment.NewLine;
            

        }

        private void CreateDeveloper_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(CreateDeveloper));
        }

        private void CreateGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewGame));
        }

        private void CreateReview_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void CreateReview_Click_1(object sender, RoutedEventArgs e)
        {
            //testataan sql

            SQL_queryies query = new SQL_queryies();

            /*
            Developer new2 = new Developer("Joku3", "", "", "");
            Developer new3 = new Developer("Joku2", "", "", "");
            Statistics Statistics = new Statistics();

            Statistics.ListOfDevelopers.Add(new2.Name, new2);
            Statistics.ListOfDevelopers.Add(new3.Name, new3);
            */

            query.SQL_Query_GetGames();



        }

        private void Debug_xml(object sender, RoutedEventArgs e)
        {
            //XML news = new XML();
           



        }
    }
}
