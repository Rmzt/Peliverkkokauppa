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
        public string ScoreNumber { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }

        public List<Double> Values = new List<Double>();

        public GamePage()
        {
            this.InitializeComponent();

        
            Values.Add(Convert.ToDouble(0));
            Values.Add(Convert.ToDouble(0.5));
            Values.Add(Convert.ToDouble(1));
            Values.Add(Convert.ToDouble(1.5));
            Values.Add(Convert.ToDouble(2));
            Values.Add(Convert.ToDouble(2.5));
            Values.Add(Convert.ToDouble(3));
            Values.Add(Convert.ToDouble(3.5));
            Values.Add(Convert.ToDouble(4));
            Values.Add(Convert.ToDouble(4.5));
            Values.Add(Convert.ToDouble(5));




              

            if (Statistics.IsCustomer == true)
            {
                if (Statistics.LoggedInUser.OwnedGame.ContainsValue(Selection))
                {
                    Buy.Visibility = Visibility.Collapsed;
                }

            }
            else
            {
                Buy.Visibility = Visibility.Collapsed;
            }

            Price.Text = Convert.ToString(Price_input);
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Otetaan vastaan sivulle siiretty data valitusta pelistä.
            base.OnNavigatedTo(e);

            

            if (e.Parameter is Game)
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

                ScoreNumber = Selection.GetScore();

                Info.Text = "Info:\nGenre: " + Genre + "\nDeveloper: " + Developer + "\nRelease Date: " + ReleaseDate.ToString();
                Cover = Selection.Coverimg;


               



            /* Tämä ei toiminut, eikä sitä varmaan tarvitsekaan. Kuvan data bindattu Cover stringiin.
            Uri imageUri = new Uri(Cover, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            image.Source = imageBitmap;
            */



        }



    }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {   
            if(Statistics.IsCustomer == true)
            {
                if (Statistics.LoggedInUser.OwnedGame.Values.Contains(Selection))
                {
                    //On jo sivun luonti konstruktorissa käsitelty
                }
                else
                {
                    Statistics.LoggedInUser.AddOwnedGame(Selection.GameID, Selection);
                }
                
            }
            
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }

        private void Rating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ConfirmReview_Click(object sender, RoutedEventArgs e)
        {
            if(Rating.SelectedValue != null)
            {
                Score.TextAlignment = TextAlignment.Left;
                Score.FontSize = 15;
                Score.Text = "Review added: ";

                bool Exists = false;
                //Käy läpi kaikki pelin arvostelut. JOs käyttäjä on jo antanut arvostelun ei hän voi sitä uudestaan
                //antaa.

                foreach(Review rew in Selection.Reviews.Values)
                {
                    if(rew.Username == Statistics.Userloggedin)
                    {
                        Exists = true;
                        break;
                    }
                }
                
                if(Exists != true && Statistics.Userloggedin != null)
                {
                    int i = Selection.Reviews.Values.Count + 1;
                    if(Statistics.IsCustomer == true)
                    {
                        
                        float x = float.Parse(Rating.SelectedValue.ToString());

                        Review review = new Review(i, Statistics.LoggedInUser.Username, x);
                        Selection.AddReview(i, review);



                    } else
                    {

                        float x = float.Parse(Rating.SelectedValue.ToString());

                        Review review = new Review(i, Statistics.LoggedInEmployee.Username, x);
                        Selection.AddReview(i, review);
                    }
                    
                } else
                {
                    
                }
                
            }
        }
    }
}
