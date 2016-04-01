using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    class Customer : Person
    {
        public Dictionary<int, Game> OwnedGame { get; set; }
        public List<Customer> Customers { get; set; }
        public Customer(string firstname, string lastname, string username, string password, string email, int phonenumber, string address, DateTime accountCreated)
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

        public void CreateDummyCustomer(int times)
        {
         //Luodaan testidataa
               
            for (int i = 0; i < times; i++)
            {
                Customers.Add(new Customer("Etunimi" + i, 
                    "Sukunimi" + i, 
                    Firstname + Lastname, 
                    "Password" + i, 
                    "Email" + i,
                    1032154642 + i,
                    "address" + i,
                    DateTime.Now));
            } 
        }

    }
}
