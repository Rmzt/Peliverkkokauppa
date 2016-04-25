﻿using System;
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
        public List<News> News_list { get; set; }

        public News newestNews { get; set; }

        public Frontpage()
        {
            Listat = new List<Game>();

            foreach (Game game in Lista.Values)
            {
                Listat.Add(game);
            }

            // Username_output.Text = Statistics.LoggedInUser.Username;

            try
            {
                this.InitializeComponent();
                
                Statistics stat = new Statistics();

                News_list = stat.ListofNews();

               List<News> OrderedList = News_list.OrderBy(o => o.Date).ToList();
               newestNews = News_list[0];

                News_Outbox.Text = string.Format("{0}", newestNews.Title + Environment.NewLine);
                News_Outbox.Text += string.Format("{0}", newestNews.Date.Date.ToString("MMMM dd, yyyy") + Environment.NewLine);
                News_Outbox.Text += string.Format("{0}", newestNews.Content + Environment.NewLine);


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
            //siirtää asiakkaan pelisivulle
            Game peli = (Game)e.ClickedItem;
            this.Frame.Navigate(typeof(GamePage), peli);
        }

        private void Game_By_Genre_Tapped(object sender, TappedRoutedEventArgs e)
        {
           // this.Frame.Navigate(typeof(SearchPage));
        }


        private void Selailu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameSearch));
        }

        private void NewGames_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage), e.ClickedItem);
        }
    }

    }

