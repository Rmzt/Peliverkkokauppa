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
    public sealed partial class CreateNews : Page
    {
        public string input_title { get; set; }
        public string input_Content { get; set; }

        public CreateNews()
        {
            this.InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            bool error = false;

            input_title = Title.Text;

            if(input_title.Length <= 0)
            {
                error = true;
                Title_Error.Text = "Title has to be longer than 0";
            }

            input_Content = Content.Text;

            if(input_Content.Length < 0)
            {
                error = true;
                Error_content.Text = "Content has to be longer than 0 letters";   
            }

            if(error == false)
            {

                News news = new News(input_title, input_Content, DateTime.Now);

                bool exists = Statistics.NewsList.Any(x => x.Title == news.Title);

                if (exists == true)
                {
                    SystemInfo.Text = "Title is already in use";

                }
                else
                {
                    Statistics.NewsList.Add(news);
                    SystemInfo.Text = string.Format("Created new newsletteri: {0}", news.Title);
                }
                
            }
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Frontpage));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Statistics stat = new Statistics();
            stat.Logout();
            Frame.Navigate(typeof(login1));
        }
    }
}
