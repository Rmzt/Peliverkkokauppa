﻿using System;
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

        private static List<Customer> ListofCustomers { get; set; }

        internal static Customer LoggedInUser = new Customer();
        internal static Employee LoggedInEmployee = new Employee();


        public static bool IsCustomer = true; //defaulttina käyttäjä on asiakas, jos muuten ei tietoa muuteta

        //public static Customer LoggedInCustomer { get; set; }



        public void Logout()
        {
            LoggedInUser = null;
            IsCustomer = true;
        }

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

        internal List<Customer> CustomersList()
        {

            List<Customer> ListofCustomers = new List<Customer>();
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Customer.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                Customer Customer = new Customer(arrays[0], arrays[1], arrays[2], arrays[3], arrays[4], Convert.ToString(arrays[5]), arrays[6], Convert.ToDateTime(arrays[7]));
                ListofCustomers.Add(Customer);
            }

            return ListofCustomers;
        }

        internal List<Employee> EmployeeList()
        {

            List<Employee> ListofEmployees = new List<Employee>();
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Employees.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                Employee employee= new Employee(arrays[0], arrays[1], arrays[2], arrays[3], arrays[4], Convert.ToString(arrays[5]), arrays[6], Convert.ToDateTime(arrays[7]));
                ListofEmployees.Add(employee);
            }

            return ListofEmployees;
        }

        /* ignore tämä, olikin toteutettu login1 sivulle

        private Dictionary<int, Game> GamesList()
        {
            Dictionary<int, Game> ListOfGames = new Dictionary<int, Game>();
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Games.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                Game Game = new Game(Convert.ToInt32(arrays[0]), arrays[1], arrays[2], float.Parse(arrays[3]), arrays[4], arrays[5], Convert.ToDateTime(arrays[6]), arrays[7]);
                ListOfGames.Add(Game.GameID, Game);
            }

            return ListOfGames;
        }

        */


        public bool Authenticate(string username, string password)
        {

            List<Employee> Employees = EmployeeList();
            List<Customer> Customers = CustomersList();

            foreach(Customer user in Customers)
            {
                if(user.Username == username && user.Password == password)
                {
                    Statistics.LoggedInUser = Customers.Find(Customer => Customer.Username.Contains(username) && Customer.Password.Contains(password));

                    LoggedInUser.OwnedGame = GetOwnedGames(LoggedInUser);

                    return true;
                }
            }

            foreach (Employee emplo in Employees)
            {
                if (emplo.Username == username && emplo.Password == password)
                {
                    Statistics.LoggedInEmployee = Employees.Find(Employee => Employee.Username.Contains(username) && Employee.Password.Contains(password));

                    Statistics.IsCustomer = false;
                    return true;
                }
            }

            return false;
        }

        private Dictionary<int,Game> GetOwnedGames(Customer customer)
        {
            Dictionary<int, Game> Games = new Dictionary<int, Game>();

            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Transactions.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));

                if (arrays[2] == customer.Username)
                {
                    Games.Add(Convert.ToInt32(arrays[0]), ListOfGames[Convert.ToInt32(arrays[0])]);
                }
            }

            return Games;
        }

    }
}
