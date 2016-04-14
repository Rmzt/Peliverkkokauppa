using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    /// 
    /// Jos aikaa niin lisätään paremmat error tarkistukset, esim että vain kirjaimia ja - merkkejä käytetty firstname ja lastname kohdissa
    /// 
    /// </summary>

        
        



    public sealed partial class CreateAccount1 : Page
    {
        //int fname, lname, uname, pw1, pw2, email, phone, address;

        public CreateAccount1()
        {
            this.InitializeComponent();
        }

        private void Palaa_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Sulje_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }

        private void Luo_Click(object sender, RoutedEventArgs e)
        {
            // Luo näppäin vie tällä hetkellä suoraan pääsivulle tekemättä mitään
            this.Frame.Navigate(typeof(Frontpage));
        }

        // Tästä alkaa error tarkistukset 

        private void Firstname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Firstname.Text.Length < 2)
                E_Firstname.Text = "Minimum length is 2 characters";
            else if (Firstname.Text.Length > 20)
                E_Firstname.Text = "Maximum length is 20 characters";
            else
                E_Firstname.Text = "";
        }

        private void Lastname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Lastname.Text.Length < 2)
                E_Lastname.Text = "Minimum length is 2 characters";
            else if (Lastname.Text.Length > 20)
                E_Lastname.Text = "Maximum length is 20 characters";
            else
                E_Lastname.Text = "";
        }

        private void Username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Username.Text.Length < 5)
                E_Username.Text = "Minimum length is 5 characters";
            else if (Username.Text.Length > 20)
                E_Username.Text = "Maximum length is 20 characters";
            else
                E_Username.Text = "";
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            // if (System.Text.RegularExpressions.Regex.IsMatch(Password.Password.Trim(), "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9_@.-]).{8,}$"))
            // tuo ylläoleva kait palauttaa true arvon jos löytyy 1 lowercase, 1 uppercase, 1 number ja + special character

            if (!Password.Password.Any(char.IsLower))
                E_Password.Text = "Missing atleast 1 lower case character";
            else if (!Password.Password.Any(char.IsUpper))
                E_Password.Text = "Missing atleast 1 upper case character";
            else if (!Password.Password.Any(char.IsDigit))
                E_Password.Text = "Missing atleast 1 number";
            else if (Password.Password.Length < 8)
                E_Password.Text = "Minimum length is 8 characters";
            else if (Password.Password.Length > 15)
                E_Password.Text = "Maximum length is 15 characters";
            else
                E_Password.Text = "";

            if (Password.Password == Password_Repeat.Password)
            {
                E_Password_Repeat1.Text = "";
                E_Password_Repeat2.Text = "Passwords match!";               
            }
            else
            {
                E_Password_Repeat2.Text = "";
                E_Password_Repeat1.Text = "Passwords DON'T match!";
            }



        }

        private void Password_Repeat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Password == Password_Repeat.Password)
            {
                E_Password_Repeat1.Text = "";
                E_Password_Repeat2.Text = "Passwords match!";
            }
            else
            {
                E_Password_Repeat2.Text = "";
                E_Password_Repeat1.Text = "Passwords DON'T match!";
            }
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Email.Text.ToLower().Contains('@'))
                E_Email.Text = "Missing @-character";
            else if (Email.Text.Length < 6)
                E_Email.Text = "Minimum length is 6 characters";
            else if (Email.Text.Length > 45)
                E_Email.Text = "Maximum length is 45 characters";
            else
                E_Email.Text = "";
        }

        private void Phonenumber_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = true;

            foreach (char c in Phonenumber.Text)
            {
                if (c < '0' || c > '9')
                    test = false;                    
            }

            if (!test)
                E_Phonenumber.Text = "Only numbers are allowed!";
            else if (Phonenumber.Text.Length < 6)
                E_Phonenumber.Text = "Minimum length is 6 characters";
            else if (Phonenumber.Text.Length > 15)
                E_Phonenumber.Text = "Maximum length is 15 characters";
            else
                E_Phonenumber.Text = "";

        }

        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Address.Text.Length < 2)
                E_Address.Text = "Minimum length is 2 characters";
            else if (Address.Text.Length > 30)
                E_Address.Text = "Maximum length is 30 characters";
            else
                E_Address.Text = "";
        }

        // Tähän loppui error tarkistukset
    }
}
