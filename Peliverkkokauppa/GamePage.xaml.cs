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
using Windows.UI.Xaml.Media.Imaging; // tämä piti lisätä että sai tuon cover image converterin toimimaan
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        public Game Selection { get; set; }

        public string Name_input { get; set; }
        public string Description { get; set; }
        public float Price_input { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Cover { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }


        public GamePage()
        {
            this.InitializeComponent();
            Price.Text = Convert.ToString(Price_input);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(login1));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Profiili));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Otetaan vastaan sivulle siiretty data valitusta pelistä.

            if(e.Parameter is Game)
            {
                Selection = (Game)e.Parameter;

                Name_input = Selection.Name;
                Title.Text = Name_input;


                Description = Selection.Description;
                Description_t.Text = Description;

                Price_input = Selection.Price;                
                Price.Text = Price_input.ToString() + "€";

                Genre = Selection.Genre;
                Developer = Selection.Developer;
                Cover = Selection.Coverimg;
                ReleaseDate = Selection.ReleaseDate;

                Info.Text = "Info:\nGenre: " + Genre + "\nDeveloper: " + Developer + "\nRelease Date: " + ReleaseDate.ToString();
                //Cover = Selection.Coverimg;
                Cover = "Assets/coverimg/pelipeli.bmp"; //testi kuva

                Uri imageUri = new Uri(Cover, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                Image myImage = new Image();
                image.Source = imageBitmap;



                
            }


            base.OnNavigatedTo(e);
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
