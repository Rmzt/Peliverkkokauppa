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
        internal ObservableCollection<object> AccountList = new ObservableCollection<object>();
        
        public UserManagment()
        {
            this.InitializeComponent();

            foreach (Customer customer in Statistics.Stat_CustomersList)
            {
                AccountList.Add(customer);
            }

            

            
        }


        public void SelectedList(string type)
        {
            switch (type)
            {
                case "Employee":
                    AccountList.Clear();

                    foreach (Employee employee in Statistics.Stat_EmployeeLists)
                    {
                        AccountList.Add(employee);
                    }

                    break;

                case "Customer":
                    AccountList.Clear();

                    foreach (Customer customer in Statistics.Stat_CustomersList)
                    {
                        AccountList.Add(customer);
                    }
                    break;
            }
        }
    }

    
}
