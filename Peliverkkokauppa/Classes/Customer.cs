using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Peliverkkokauppa
{
    class Customer : Person
    {
        public Dictionary<int, Game> OwnedGame = new Dictionary<int, Game>();
        public List<Customer> Customers { get; set; }
        public Customer(string firstname, string lastname, string username, string password, string email, string phonenumber, string address, DateTime accountCreated)
            : base (firstname, lastname, username, password, email, phonenumber, address, accountCreated)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Password = password;
            Email = email;
            Phonenumber = phonenumber;
            Address = address;
            AccountCreated = accountCreated;

            OwnedGame = new Dictionary<int, Game>();
        }

        public Customer()
        {
            OwnedGame = new Dictionary<int, Game>();
        }

        public void RemoveOwnedGame(int i)
        {
            if (OwnedGame.ContainsKey(i))
            {
                OwnedGame.Remove(i);
            }
        }

        public void AddOwnedGame(int i, Game t)
        {
            OwnedGame.Add(i, t);
        }


       

        public Dictionary<int, Game> GetOwnedGames()
        {
            Dictionary<int, Game> UsersGames = new Dictionary<int, Game>();

            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Customer.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                Developer dev = new Developer(arrays[0], arrays[1], arrays[2], arrays[3]);
                Statistics.ListOfDevelopers.Add(dev.Name, dev);
            }

            return UsersGames;
        }

    }
}
