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
    public sealed partial class login1 : Page
    {
        public Statistics statistics = new Statistics();
      
        public login1()
        {
            this.InitializeComponent();
        }

        private void NeAcc_Click(object sender, RoutedEventArgs e)
        {
            //Siirrytään käyttäjätunnuksen luomiseen
            this.Frame.Navigate(typeof(CreateAccount1));

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //Lisätään koodi, jolla tarkistetaan käyttäjätunnuksen olemassaolo

            SQL_queryies sql = new SQL_queryies();

            try { 
            sql.ConnectToSQL().Open();
            } catch(Exception error_e)
            {
                ErrorBlock.Text = "No connection to server. Try again later";
            }


            string Username = UsernameBox.Text;
            string Password = PasswordBox.Password;

            Authenticate Auth = new Authenticate();

            /*

            HUOM! ... MySQL ei tällä hetkellä tue SSL-salausta, joten salasanat ja käyttäjätunnukset kannattaa encryptata, jotenkin ennen
            tiedon lähettämistä palvelimelle.

            */

            bool IsValidAccount = Auth.AuthenticateUser(Username, Password);
            
            
            if(IsValidAccount == true)
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

        private void Debugger_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Debugger));
        }

        private void Fpass_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RestorePass1));
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }
    }
}
