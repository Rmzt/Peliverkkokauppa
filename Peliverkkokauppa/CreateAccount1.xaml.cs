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
    /// Sivuston virheilmoitukset voisivat olla tarkempia.
    /// esim. Jos etunimi <= 0 niin ilmoitetaan "Etunimi ei saa olla tyhja tai pienempi kuin nolla"
    /// Kayta errortekstilaatikkon Onchange toimintoa.
    /// </summary>



    public sealed partial class CreateAccount1 : Page
    {
        public CreateAccount1()
        {
            this.InitializeComponent();
        }

        private void Palaa_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
