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
using System.IO.Compression;
using Windows.Data.Text;
using System.Text;
using Windows.Security.Cryptography.Core;
using Windows.UI.Core;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class login1 : Page
    {
        public Statistics statistics = new Statistics();
        public bool isConnected { get; set; }
        public static bool Firsttry = true;    


        public login1()
        {
            if(Firsttry == true)
            {
                readData();
                statistics.ListofNews();
                statistics.CustomersList();
                statistics.EmployeeList();
                Firsttry = false;
            }

            this.InitializeComponent();
            
        }

        private void NeAcc_Click(object sender, RoutedEventArgs e)
        {
            //Siirrytään käyttäjätunnuksen luomiseen
            this.Frame.Navigate(typeof(CreateAccount1));

        }
        



        public async void WriteInputsToLocalFile()
        {
            //Jos paikallisia tiedostoja ei ole olemassa ne luodaan.

            /*

            1. Tarkista onko tiedostot olemassa
            2. Jos ei Kirjoita tekstitiedostojen sisältö localtiesdostoon
            3. Jos kyllä ei tehdä mitään.

            */


            if (await statistics.LocalFilesExists() == false)
            {
                await statistics.CreateFile("Customer.txt");
                await statistics.CreateFile("Developer.txt");
                await statistics.CreateFile("Employees.txt");
                await statistics.CreateFile("Games.txt");
                await statistics.CreateFile("Genres.txt");
                await statistics.CreateFile("Transactions.txt");

             
            }



        }











        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string Username = UsernameBox.Text;
            string Password = PasswordBox.Password;

            bool IsValidAccount = statistics.Authenticate(Username, Password);
            
            if (IsValidAccount == true)
            {

                this.Frame.Navigate(typeof(Frontpage));
            }
            else
            {
            
                ErrorBlock.Text = "Login failed. Try again";      
                PasswordBox.Password = "";
            }



        }

        

        private void Exit_click(object sender, RoutedEventArgs e)
        {
                      App.Current.Exit();
        }


        private void Fpass_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RestorePass1));
        }

     

        public void readData()
        {
            
            try { 

                //Genren lukeminen
                string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Genres.txt");

                foreach (string line in mydocument)
                {
                    Statistics.ListOfGenres.Add(line);

                }


                //Kehittäjien lukeminen
                mydocument = System.IO.File.ReadAllLines(@"Assets/Developer.txt");

                foreach (string line in mydocument)
                {
                    string[] arrays = line.Split(Convert.ToChar(";"));
                    Developer dev = new Developer(arrays[0], arrays[1],arrays[2],arrays[3]);
                    Statistics.ListOfDevelopers.Add(dev.Name,dev);
                }

                mydocument = System.IO.File.ReadAllLines(@"Assets/Games.txt");

                foreach (string line in mydocument)
                {
                    string[] arrays = line.Split(Convert.ToChar(";"));
                    Game game = new Game(Convert.ToInt32(arrays[0]), arrays[1], arrays[2], float.Parse(arrays[3]), arrays[4], arrays[5], Convert.ToDateTime(arrays[6]), arrays[7]);
                    //Game game = new Game(arrays[1], arrays[2], Convert.ToUInt32(arrays[3]), arrays[4], arrays[5], Convert.ToDateTime(arrays[6]));
                    //game.GameID = Convert.ToInt32(arrays[0]);
                    Statistics.ListOfGames.Add(game.GameID, game);
                }

                mydocument = System.IO.File.ReadAllLines(@"Assets/Reviews.txt");

                foreach (string line in mydocument)
                {
                    string[] arrays = line.Split(Convert.ToChar(";"));
                    Review review = new Review(Convert.ToInt32(arrays[0]), arrays[1], Convert.ToInt32(arrays[2]));

                    foreach(Game game in Statistics.ListOfGames.Values)
                    {
                        if(game.GameID == Convert.ToInt32(arrays[3]))
                        {
                            game.AddReview(Convert.ToInt32(arrays[0]), review);
                        }
                    }

                }


                

            }
            catch (Exception x)
            {
                string y = x.Message;
            }

            
        }

        
    }
}
