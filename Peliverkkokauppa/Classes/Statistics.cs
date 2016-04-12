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
        public Dictionary<int,Game> ListOfGames { get; set; }
        public Dictionary<string, Developer> ListOfDevelopers { get; set; }
        internal Dictionary<int, Customer> ListOfCustomers { get; set; }
        
        public Statistics()
        {

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

        public void AddtoList(string List, Developer X)
        {

            Developer InsertDev = new Developer(X.Name,X.Address,X.Description,X.Email);
            ListOfDevelopers.Add(X.Name, InsertDev);
                  
        }


    }
}
