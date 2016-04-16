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
    public sealed partial class CreateDeveloper : Page
    {
        public Statistics Statistics = new Statistics();
        public Developer NDew { get; set; }

        public CreateDeveloper()
        {
            
            this.InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            String Name = Name_input.Text;
            String Address = Address_input.Text;
            String Description = Description_input.Text;
            String Email = Email_input.Text;

            
            if(ValidName(Name) == true && ValidAddress(Address) == true)
            {
                Developer newPublisher = new Developer(Name, Address, Description, Email);

                SQL_queryies sql = new SQL_queryies();


                try { 
                    sql.TestConnection();
                    if (Statistics.AddtoDev(newPublisher) == true)
                    {
                        this.Frame.Navigate(typeof(CreateDeveloper_P2), newPublisher);
                    }
                    else
                    {
                        System_error.Text = "Creating new Developer has failed";
                    }
                }

                catch (Exception)
                {

                }
              }

        }

        public bool ValidName(string name)
        {
            if (name.Length <= 4)
            {
                Name_error.Text = "Name has to be larger or same as 4";
                return false;
            }
            return true;

        }

        public bool ValidAddress(string address)
        {
            if (address.Length < 6)
            {
                Address_error.Text = "Address has to be larger or same as 6";
                return false;
            }
            return true;
        }

    }
}
