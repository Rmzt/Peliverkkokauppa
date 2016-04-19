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
        public static List<string> ListOfGenres = new List<string>();


        public static string LoggedInUser { get; set; }
        public static bool IsCustomer = true; //defaulttina käyttäjä on asiakas, jos muuten ei tietoa muuteta

        //public static Customer LoggedInCustomer { get; set; }

        public static Dictionary<int, Game> OwnedGames = new Dictionary<int, Game>();




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

        public bool AddtoDev(Developer X)
        {
            SQL_queryies sql = new SQL_queryies();


            try {
                Developer InsertDev = new Developer(X.Name, X.Address, X.Description, X.Email);
                sql.SQL_Insert_Developer(InsertDev);
                ListOfDevelopers.Add(X.Name, InsertDev);           
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public void Logout()
        {
            LoggedInUser = "";
            IsCustomer = true;
            OwnedGames.Clear();
        }
    }
}
