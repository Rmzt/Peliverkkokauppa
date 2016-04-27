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
using System.Reflection;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserManagment : Page
    {
        internal ObservableCollection<Customer> AccountCustomers = new ObservableCollection<Customer>();
        internal ObservableCollection<Employee> AccountEmployee = new ObservableCollection<Employee>();

        public UserManagment()
        {
            this.InitializeComponent();

            foreach (Customer customer in Statistics.Stat_CustomersList)
            {
                AccountCustomers.Add(customer);
            }

            foreach (Employee employee in Statistics.Stat_EmployeeLists)
            {
                AccountEmployee.Add(employee);
            }


        }


        public void SelectedList(string type)
        {
            switch (type)
            {
                case "Employee":

                    AccountGrid.ItemsSource = AccountEmployee;

                    break;

                case "Customer":

                    AccountGrid.ItemsSource = AccountCustomers;
                    
                    break;
            }
        }

        private void AccoutTypes_Toggled(object sender, RoutedEventArgs e)
        {

            string type;

            if (AccoutTypes.IsOn)
            {
                type = "Employee";
            } else
            {
                type = "Customer";
            }

            SelectedList(type);
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Statistics stat = new Statistics();
            stat.Logout();
            this.Frame.Navigate(typeof(login1));

        }
    }

    
}
