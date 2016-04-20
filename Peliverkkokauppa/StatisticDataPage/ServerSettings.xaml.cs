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
using System.Resources;
using Windows.Data.Text;
using Windows.Storage.FileProperties;

using Windows.Storage.Streams;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServerSettings : Page
    {

       
        public SQL_queryies SQL = new SQL_queryies();

        public ServerSettings()
        {
            this.InitializeComponent();

            Server_box.Text = SQL.path;
            UBox.Text = SQL.user;
            Pbox.Password = SQL.password;
            Dbox.Text = SQL.database;

 

            /*
            try { 
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/ConnectionSettings.txt");

                foreach (string line in mydocument)
                {
                    x += line; 
                }

            }
            catch (Exception)
            {

            }

            */

        }


        public void ChangeInfo(string x, string y, string z, string xy)
        {
           SQL.path = x;
           SQL.user = y;
           SQL.password = z;
           SQL.database = xy;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            ChangeInfo(Server_box.Text, UBox.Text, Pbox.Password, Dbox.Text);


        }

        private void ServerTest_Click(object sender, RoutedEventArgs e)
        {
            if(SQL.TestConnection() == false)
            {
                TestOutput.Text = "Connecting to server has failed. Try again.";
            }
            else
            {
                TestOutput.Text = "Connecting to " + SQL.database + " was successfull.";
            }
        }

        
        }
    }
