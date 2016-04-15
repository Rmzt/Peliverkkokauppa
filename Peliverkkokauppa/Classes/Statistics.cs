using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication;
using Windows.Security.Cryptography.Core;
namespace Peliverkkokauppa
{
    public class Statistics
    {
        //work in progress
        public static Dictionary<int, Game> ListOfGames = new Dictionary<int, Game>();
        public static Dictionary<string, Developer> ListOfDevelopers = new Dictionary<string, Developer>();
        internal Dictionary<int, Customer> ListOfCustomers = new Dictionary<int, Customer>();
        public static List<string> ListOfGenres = new List<string>();
        public Statistics()
        {

        }
        
        public int CountCustomer()
        {
            int i = ListOfCustomers.Count;
            return i;
        }
        
        
              
        public bool Authentication(string Username, string Password)
        {

           /* 
            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(Password);
            CryptographicKey
            CryptographicHash hash = CryptographicEngine.Encrypt(Password, 0, buffer.Length);

            string encrypted;
            */
                
            return true;
        }

        public bool AddtoDev(Developer X)
        {
            try {
                Developer InsertDev = new Developer(X.Name, X.Address, X.Description, X.Email);
                ListOfDevelopers.Add(X.Name, InsertDev);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }


    }
}
