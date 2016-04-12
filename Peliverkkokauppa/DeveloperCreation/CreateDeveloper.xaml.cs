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
        public Statistics stat { get; set; }

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

            
            Developer newPublisher = new Developer(Name,Address,Description,Email);
            stat.ListOfDevelopers.Add(newPublisher.Name,newPublisher);
            this.Frame.Navigate(typeof(CreateDeveloper_P2),newPublisher);

        }
    }
}
