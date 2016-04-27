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
    public sealed partial class EmployeePage : Page
    {
        internal Employee user = Statistics.LoggedInEmployee;

        public EmployeePage()
        {
            this.InitializeComponent();

            string title = "------" + user.Username + "------";
            int countlenght = title.Length;
            string ender = new string('-', countlenght);
            UserOutput.Text += "------" + user.Username + "------" + Environment.NewLine;
            UserOutput.Text += "Name: " + user.Firstname + " " + user.Lastname + Environment.NewLine;
            UserOutput.Text += "Phonenumber: " + user.Phonenumber + Environment.NewLine + " Address: " + user.Address + Environment.NewLine;
            UserOutput.Text += ender;

        }

        private void Create_Game_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewGame));
        }

        private void Create_Developer_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateDeveloper));
        }

        private void Create_Employee_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EmployeeCreation));
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

        private void ManageProfile_Click(object sender, RoutedEventArgs e)
        {
            string parameter = "OwnData";
            this.Frame.Navigate(typeof(EmployeeCreation),parameter);
        }

        private void CreateNewsletter_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateNews));
        }

        private void Manage_Games_Click(object sender, RoutedEventArgs e)
        {
            string parameter = "ChangeGames";

            this.Frame.Navigate(typeof(GameSearch), parameter);
        }

        private void Manage_Developers_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserManagment));
        }
    }
}
