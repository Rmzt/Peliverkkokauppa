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
    public sealed partial class EmployeeCreation : Page
    {
        //Jos halutaan muuttaa tietoja
        public Statistics stat = new Statistics();
        public bool ChangeData = false;
        public string Accounttype { get; set; }

        internal Employee employee { get; set; }
        internal Customer customer { get; set; }

        public EmployeeCreation()
        {
            this.InitializeComponent();

            if(ChangeData != false)
            {
                customer_employee.Visibility = Visibility.Collapsed;
            }

        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Statistics stat = new Statistics();
            stat.Logout();
            this.Frame.Navigate(typeof(login1));
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }

        private void Save_Employee_Click(object sender, RoutedEventArgs e)
        {
            int i;
            bool AcceptInput = true;

            if(Firstname.Text.Length < 4 || int.TryParse(Firstname.Text, out i))
            {
                Error_Firstname.Text = "Firstname has to be longer than 4 and only letters";
                AcceptInput = false;
            }

            if (Lastname.Text.Length < 4 || int.TryParse(Lastname.Text, out i))
            {
                Error_Lastname.Text = "Lastname has to be longer than 4 and only letters";
                AcceptInput = false;
            }

            if (Username.Text.Length <= 8)
            {
                Error_Username.Text = "Has to be 8 characters long or longer";
                AcceptInput = false;
            }

            if (Password.Password.Length < 8)
            {
                Error_password.Text = "Has to be 8 characters long or longer";
                AcceptInput = false;
            }

            if (Address.Text.Length < 5)
            {
                Error_address.Text = "Has to be longer than 5";
                AcceptInput = false;
            }

            if (Phonenumber.Text.Length < 8 || int.TryParse(Phonenumber.Text, out i) == false)
            {
                ErrorPhone.Text = "Has to be longer than 8 and must be only numbers";
                AcceptInput = false;
            }


            if (customer_employee.IsOn)
            {
                Accounttype = "Employee";
            }

            //Varmistetaan että tiedot ovat hyväksyttäviä ja käyttäjä ei ole jo olemassa.
            if (AcceptInput != false && stat.UserExists(Username.Text) == true)
            {
                if(ChangeData == false)
                {
                    //Jos lisätään uusia käyttäjiä



                    if (Accounttype == "Employee")
                    {
                        
                        //Jos luodaan työntekijä
                        Employee employee = new Employee(Firstname.Text, Lastname.Text, Username.Text, Password.Password, Email.Text, Phonenumber.Text, Address.Text, DateTime.Now);
                        System_info.Text = string.Format("New account created! User: {0}, Account type: {1}", employee.Username, Accounttype);
                        Statistics.Stat_EmployeeLists.Add(employee);
                    } else
                    {
                        //Jos luodaan Asiakas
                        Customer customer = new Customer(Firstname.Text, Lastname.Text, Username.Text, Password.Password, Email.Text, Phonenumber.Text, Address.Text, DateTime.Now);
                        System_info.Text = string.Format("New account created! User: {0}, Account type: {1}", customer.Username, Accounttype);
                        Statistics.Stat_CustomersList.Add(customer);
                    }
                    
                }
                else
                {
                    if (customer_employee.IsOn)
                    {
                        //Muutetaan valitun työntekijän tietoja
                        Employee employee = new Employee(Firstname.Text, Lastname.Text, Username.Text, Password.Password, Email.Text, Phonenumber.Text, Address.Text, DateTime.Now);
                    } else
                    {
                        //Muutetaan valitun asiakkaan tietoja tietoja
                        Customer customer = new Customer(Firstname.Text, Lastname.Text, Username.Text, Password.Password, Email.Text, Phonenumber.Text, Address.Text, DateTime.Now);
                    }
                    
                }
                
            } else
            {
                if(stat.UserExists(Username.Text) == false)
                {
                    System_info.Text = "Error. User already exists!";
                }
                else
                {
                    System_info.Text = "Error. Input is not valid";
                }
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter is Employee)
            {
                Employee emp = (Employee)e.Parameter;
                employee = emp;
                Firstname.Text = emp.Firstname;
                Lastname.Text = emp.Lastname;

                Username.Text = emp.Username;
                Password.Password = emp.Password;

                Email.Text = emp.Email;
                Address.Text = emp.Address;
                Phonenumber.Text = emp.Phonenumber;

                Accounttype = "Employee";
                ChangeData = true;
            }

            if (e.Parameter is Customer)
            {
                Customer emp = (Customer)e.Parameter;
                customer = emp;
                Firstname.Text = emp.Firstname;
                Lastname.Text = emp.Lastname;

                Username.Text = emp.Username;
                Password.Password = emp.Password;

                Email.Text = emp.Email;
                Address.Text = emp.Address;
                Phonenumber.Text = emp.Phonenumber;

                Accounttype = "Customer";
                ChangeData = true;
            }

            if(e.Parameter is String)
            {
                Employee PersonalData = Statistics.LoggedInEmployee;
                employee = PersonalData;
                Firstname.Text = PersonalData.Firstname;
                Lastname.Text = PersonalData.Lastname;

                Username.Text = PersonalData.Username;
                Password.Password = PersonalData.Password;

                Email.Text = PersonalData.Email;
                Address.Text = PersonalData.Address;
                Phonenumber.Text = PersonalData.Phonenumber;

                Accounttype = "Employee";
                ChangeData = true;
            }

            if(e.Parameter == null){
                customer_employee.Visibility = Visibility.Visible;
                ChangeData = false;

            }

            base.OnNavigatedTo(e);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}
