using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Peliverkkokauppa
{

   class Authenticate
    {
        public SQL_queryies Sql { get; set; }

        public Authenticate()
        {

        }

        public bool AuthenticateUser(string Username, string Password)
        {

            //Kun on aikaa, kokeile encryptaus ja decryptaus menetelmiä
            try {
               
                MySqlDataReader reader = Sql.Query("Select UserName, Password From customer Where UserName=\"" + Username + "\" and Password=\"" + Password + "\";");

                return true;


            } catch(NullReferenceException)
            {
                return false;
                
            }

            
        }
    }
}
