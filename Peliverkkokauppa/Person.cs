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
        public int Phonenumber { get; set; }
        public string Address { get; set; }


        public Person()
        {
        }

        
        public Person(string firstName, string lastName, string username, string password, string email, int phonenumber, string address)
        {
            Firstname = firstName;
            Lastname = lastName;
            Username = username;
            Password = password;
            Email = email;
            Phonenumber = phonenumber;
            Address = address;
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
            return FirstName + " " + LastName + " " + Address + " " + Age + " " + PhoneNumber;
        }
        */
    }

}
