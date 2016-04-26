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

        public List<Game> Listat
        {
            get; set;
        }

        public List<News> News_list { get; set; }

        public News newestNews { get; set; }

        public Frontpage()
        {         
            // Username_output.Text = Statistics.LoggedInUser.Username;

            try
            {
                this.InitializeComponent();

                News_list = Statistics.NewsList;

                Listat = Statistics.ListOfGames.Values.ToList();

               List<News> OrderedList = News_list.OrderByDescending(o => o.Date).ToList();
               newestNews = News_list[0];

                News_Outbox_Title.Text = string.Format("{0}", newestNews.Title);
                News_Outbox_Date.Text += string.Format("{0}", newestNews.Date.Date.ToString("MMMM dd, yyyy"));
                News_Outbox_Content.Text += string.Format("{0}", newestNews.Content);


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

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Image image = e.OriginalSource as Image;
            if (image != null)
            {
                
            }
        }

        private void New_Games_ItemClick(object sender, ItemClickEventArgs e)
        {
            Game peli = (Game)e.ClickedItem;

            //siirtää asiakkaan pelisivulle
            try {
                
            this.Frame.Navigate(typeof(GamePage), peli);
            }
            catch (Exception exa)
            {
                string h = exa.Message;
            }
            
         }
    
 

        private void Selailu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameSearch));
        }

        private void NewGames_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage), e.ClickedItem);
        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewsPage));
        }

        private void Output_ItemClick(object sender, ItemClickEventArgs e)
        {
            Game peli = (Game)e.ClickedItem;
            this.Frame.Navigate(typeof(GamePage), peli);
        }

       
    }

    }

