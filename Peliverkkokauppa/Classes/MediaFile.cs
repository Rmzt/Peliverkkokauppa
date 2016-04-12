using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    public class MediaFile
    {
        public int MediaID { get; set; }
        public string Path { get; set; }

        public MediaFile(int mediaID, string path)
        {
            MediaID = mediaID;
            Path = path;
        }

        public MediaFile()
        {

        }
    }
}
