using System;
using System.Resources;
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
using System.Xml;
using System.Data;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Peliverkkokauppa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewGame : Page
    {


        //GameID automaattisesti luotu?

        public string GameName { get; set; }
        public string Description { get; set; }
        public float Price
        {
            get; set;
        }

        public string Genre { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }

        public AddNewGame()
        {
            this.InitializeComponent();
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            //keskeneräinen

            GameName = Name_input.Text;
            Description = Description_input.Text;
            Price = Convert.ToInt64(Price_input.Text);
            Genre = Genre_input.Text;
            //Developer = Developer_input.Text;

            ReleaseDate = Convert.ToDateTime(ReleaseDate_input.Date.Value);

            Random rand = new Random();

            Game NewGame = new Game(rand.Next(1,999), GameName, Description, Price, Genre, "", Developer, ReleaseDate);
            
            //Luodaan kirjoittaja
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Game));

            //polku
            string path = Convert.ToString(Directory.GetCurrentDirectory()) +  "/testi.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, NewGame);
            

        }
    }
}
