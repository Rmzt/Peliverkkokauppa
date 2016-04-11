using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Peliverkkokauppa
{
    class XML
    {
        public XML()
        {
            XmlDocument document1 = new XmlDocument();
            bool istrue = document1.IsReadOnly;
            try {
                Stream writeStream = new FileStream(@"Assets\Game.xml", FileMode.Create, FileAccess.Write, FileShare.None);


                /*
                Luetaan xml dokumenttia

                document1.LoadXml(@"assets\Game.xml");
                */
                Game newgame = new Game();
                newgame.Name = "testi";

                XmlSerializer serializer = new XmlSerializer(typeof(Game));
                serializer.Serialize(writeStream, newgame);



            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
