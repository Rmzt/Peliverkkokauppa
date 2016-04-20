using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    class Person
    {               
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public DateTime AccountCreated { get; set; }


        public Person(string firstname, string lastname, string username, string password, string email, string phonenumber, string address, DateTime accountCreated)
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

        public Person()
        {

        }

        public void ChangeInformation()
        {

        }

        public void RestorePassword()
        {

        }

        /*
        public override string ToString()
        {
            return Firstname + " " + Lastname + " " + Address + " " + Phonenumber;
        }
        */
    }

}
