using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    class Review
    {
        public int ReviewID { get; set; }
        public string Username { get; set; }
        public float Stars { get; set; }
        public string ReviewGame { get; set; } //en ole varma miten tätä luokkaa käytetään tietokannassa (suhteet peliin yms), voi joutua muuttamaan erilaiseks myöhemmin tätä
        

        public Review(int reviewID, string username, float stars, string reviewGame)
        {
            ReviewID = reviewID;
            Username = username;
            Stars = stars;
            ReviewGame = reviewGame;
        }

        public Review()
        {

        }

     
    }
}
