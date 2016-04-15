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
        public SQL_queryies Sql = new SQL_queryies();

        public Authenticate()
        {

        }

        public bool AuthenticateUser(string Username, string Password)
        {

            //Kun on aikaa, kokeile encryptaus ja decryptaus menetelmiä
            try {
               
                string query = String.Format("Select * From customer Where UserName = {0} and Password = {1};", Username, Password);
                MySqlDataReader lukija = Sql.Query(query);
                return true;


            } catch(MySqlException error)
            {
                string x = error.Message;
                return false;
                
            }
            
            
        }
    }
}
