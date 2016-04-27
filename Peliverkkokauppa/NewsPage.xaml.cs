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



    public sealed partial class NewsPage : Page
    {
        public bool firstloaded = false;
        public List<News> News = new List<Peliverkkokauppa.News>();
    
        public NewsPage()
        {
            this.InitializeComponent();


            if(firstloaded == false)
            {

            List<News> news = Statistics.NewsList;

            news = news.OrderByDescending(o => o.Date).ToList();
            News = news;

                firstloaded = true;
            }



        }


       

        private void FrontPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }

        private void Browsing_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameSearch));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if(Statistics.IsCustomer == true)
            {
                this.Frame.Navigate(typeof(Profiili));
            } else
            {
                this.Frame.Navigate(typeof(EmployeePage));
            }
            
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Statistics stat = new Statistics();
            stat.Logout();
            this.Frame.Navigate(typeof(login1));
        }

        private void NewGames_ItemClick(object sender, ItemClickEventArgs e)
        {
            News news = (News)e.ClickedItem;
            Title.Text = news.Title;
            Date.Text = news.StringDate;
            Content.Text = news.Content;
        }
    }
}
