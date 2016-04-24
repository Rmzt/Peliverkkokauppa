using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using System.Reflection;


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

        internal static string Userloggedin { get; set; }

        public static bool IsCustomer = true; //defaulttina käyttäjä on asiakas, jos muuten ei tietoa muuteta

        public StorageFolder folder = ApplicationData.Current.LocalFolder;


        public static int Minimum = 0;
        public static int Maximum = 100;
        public static int LowerValue = 0;
        public static int UpperValue = 100;



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
                    Statistics.Userloggedin = LoggedInUser.Username;
                    LoggedInUser.OwnedGame = GetOwnedGames(LoggedInUser);

                    return true;
                }
            }

            foreach (Employee emplo in Employees)
            {
                if (emplo.Username == username && emplo.Password == password)
                {
                    Statistics.LoggedInEmployee = Employees.Find(Employee => Employee.Username.Contains(username) && Employee.Password.Contains(password));
                    Statistics.Userloggedin = LoggedInEmployee.Username;
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



        public void ChangeCustomers(string firstname, string lastname, string username, string password, string address, string phonenumber, string email, DateTime datecreated)
        {
            List<Customer> lista = CustomersList();
            foreach(Customer cust in lista)
            {
               
            }
        }


        public async Task<StorageFile> CreateFile(string filename)
        {
             
            //Luo appdata kasioon tiedosto
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            return file;
            
        }

        internal async void CustomerWriteToFile(string filename, List<Customer> InputList)
        {
            //Hakee tiedoston kirjoitettavaksi. Kirjoittaa tiedostoon C:/users/USER/AppData.....
            var file = await folder.CreateFileAsync(filename,CreationCollisionOption.OpenIfExists);
            var stream = await file.OpenAsync(FileAccessMode.ReadWrite);

            Type tyyppi = InputList.GetType();
            int attributeCount = 0;

            foreach (PropertyInfo property in tyyppi.GetProperties())
            {
                attributeCount += property.GetCustomAttributes(false).Count();
            }


            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using(var datawriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    datawriter.WriteString("Testi");
                    await datawriter.StoreAsync();
                    
                }
            }

            stream.Dispose();
            
        }

        public async Task<bool> LocalFilesExists()
        {
            try
            {
                await folder.GetFileAsync("Customer.txt");
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }



    }
}
