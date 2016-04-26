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
    public sealed partial class CreateDeveloper_P2 : Page
    {

        public Developer dev { get; set; }

        public CreateDeveloper_P2()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Developer)
            {
                dev = (Developer)e.Parameter;

                Output.Text = "You have successfully created a new Developer" + Environment.NewLine;
                Output.Text += "Developer name: " + dev.Name + Environment.NewLine;
                Output.Text += "Developer Address: " + dev.Address + Environment.NewLine;
                Output.Text += "Description: " + dev.Description + Environment.NewLine;
                Output.Text += "Email: " + dev.Email + Environment.NewLine;



            }



            base.OnNavigatedTo(e);
        }

        private void AddNGames_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewGame), dev);
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Frontpage));
        }

        private void Profile_Page_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EmployeePage));
        }

        private void Developer_Page_Click(object sender, RoutedEventArgs e)
        {
            Developer_Page.Content = "Out of Order";
        }

    
    }

    
}
