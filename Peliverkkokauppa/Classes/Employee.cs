using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    class Employee : Person
    {
        public Employee(string firstname, string lastname, string username, string password, string email, string phonenumber, string address, DateTime accountCreated)
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
        }

        public Employee()
        {

        }
            

        public void AddDeveloper()
        {

        }

        public void RemoveDeveloper()
        {

        }

        public void AddGame()
        {

        }

        public void RemoveGame()
        {

        }

        public void UpdateGameDetails()
        {

        }

        public void UpdateDeveloperDetails()
        {

        }
    }
}
