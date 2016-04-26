using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Username { get; set; }
        public float Stars { get; set; }


        public Review(int reviewID, string username, float stars)
        {
            ReviewID = reviewID;
            Username = username;
            Stars = stars;
        }

        public Review()
        {

        }


    }

    public class AcceptValues
    {
    
        public double Value { get; set; }

        public AcceptValues(double x)
        {
            Value = x;
        }


    }
}
