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
using System.IO.Compression;
using Windows.Data.Text;
using System.Text;
using Windows.Security.Cryptography.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{

    /// <summary>
    /// 
    /// SQL tunnuksen luominen riville 208
    /// 
    /// Tarkistukset että onko tunnus käytössä riveille 115 ja 262
    /// 
    /// </summary>
        
        
        



    public sealed partial class CreateAccount1 : Page
    {
        

      

        public CreateAccount1()
        {
            this.InitializeComponent();
        }

        //Linkki SQL INSERT-Komentoon
        /*
        1. Tarkista onko käyttäjätunnus olemassa
        2. Lisää tiedot SQL
        
            Käytä customer Insert komentoa

        */

        //Customer metodi InsertCustomer() --> vie tietokantaan

        /*
        Sql.TestConnection()
        customer.InsertCustomer(Customer cust)
        */






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
            int fname = 0, lname = 0, uname = 0, pw1 = 0, pw2 = 0, email = 0, phone = 0, address = 0;

            if (Firstname.Text.Length < 2)
                E_Firstname.Text = "Minimum length is 2 characters";
            else if (Firstname.Text.Length > 20)
                E_Firstname.Text = "Maximum length is 20 characters";
            else
            {
                E_Firstname.Text = "";
                fname = 1;
            }



            if (Lastname.Text.Length < 2)
                E_Lastname.Text = "Minimum length is 2 characters";
            else if (Lastname.Text.Length > 20)
                E_Lastname.Text = "Maximum length is 20 characters";
            else
            {
                E_Lastname.Text = "";
                lname = 1;
            }


            if (Username.Text.Length < 5)
                E_Username.Text = "Minimum length is 5 characters";
            else if (Username.Text.Length > 20)
                E_Username.Text = "Maximum length is 20 characters";
            else
            {
                E_Username.Text = "";
                uname = 1;
            }


           


            //TÄHÄN KOHTAAN TARKISTUS ONKO USERNAME JO KÄYTÖSSÄ (ja myös alemmas riville 260)
            /*

            if (Username.Text == käytössä)
            {
                uname = 0;
                E_Username.Text = "Username is already in use!";
            }

            */

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
            {
                E_Password.Text = "";
                pw1 = 1;
            }

            if (Password.Password == Password_Repeat.Password)
            {
                E_Password_Repeat1.Text = "";
                E_Password_Repeat2.Text = "Passwords match!";
                pw2 = 1;
            }
            else
            {
                E_Password_Repeat2.Text = "";
                E_Password_Repeat1.Text = "Passwords DON'T match!";
                pw2 = 0;
            }



            if (!Email.Text.ToLower().Contains('@'))
                E_Email.Text = "Missing @-character";
            else if (Email.Text.Length < 6)
                E_Email.Text = "Minimum length is 6 characters";
            else if (Email.Text.Length > 45)
                E_Email.Text = "Maximum length is 45 characters";
            else
            {
                E_Email.Text = "";
                email = 1;
            }


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
            {
                E_Phonenumber.Text = "";
                phone = 1;
            }




            if (Address.Text.Length < 2)
                E_Address.Text = "Minimum length is 2 characters";
            else if (Address.Text.Length > 30)
                E_Address.Text = "Maximum length is 30 characters";
            else
            {
                E_Address.Text = "";
                address = 1;
            }
        

            if (fname == 1 && lname == 1 && uname == 1 && pw1 == 1 && pw2 == 1 && email == 1 && phone == 1 && address == 1)
            {

                /*
                TUNNUKSEN LISÄYS PAHASTI KESKEN

                tiedot löytyvät näistä:

                Firstname.Text
                Lastname.Text
                Username.Text
                Password.Password
                Email.Text
                Phonenumber.Text
                Address.text

                */

                Statistics stat = new Statistics();

               

                if (Statistics.Stat_CustomersList.Find(o => o.Username == Username.Text) == null)
                {
                    Customer cust = new Customer(Firstname.Text, Lastname.Text, Username.Text, Password.Password, Email.Text, Phonenumber.Text, Address.Text, DateTime.Now);

                    stat.AddtoCustomers(cust);

                    Statistics.Stat_CustomersList.Add(cust);


                    int i = 0;
                }
                else
                {
                    SystemInfo.Text = "User creation failed";
                }

                /*
                System.IO.MemoryStream mStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(@"Assets/testcustomer.txt"));

                using (StreamWriter outputFile = new StreamWriter(mStream))
                {
                    outputFile.WriteLine("New Line");
                }

                */
                //login1 sivulle onpagenavigated kohtaan tarkistus että onko palautettu numero 1
                // jos on niin näytetään viesti "account creation succesful"
                //int success = 1;
                this.Frame.Navigate(typeof(login1)); 
            }

        }



        // Tästä alkaa LostFocus error tarkistukset 

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

            //TÄHÄN KOHTAAN TARKISTUS ONKO USERNAME JO KÄYTÖSSÄ (ja myös ylemmäs riville 113
            /*

            if (Username.Text == käytössä)
            {
                E_Username.Text = "Username is already in use!";
            }

            */
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
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

       
        // Tähän loppui LostFocus error tarkistukset
    }
}
