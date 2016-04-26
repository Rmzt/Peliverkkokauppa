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
        public static List<News> NewsList = new List<News>();

        internal static List<Customer> Stat_CustomersList = new List<Customer>();
        internal static List<Employee> Stat_EmployeeLists = new List<Employee>();


        public StorageFolder folder = ApplicationData.Current.LocalFolder;

        internal void AddtoCustomers(Customer x)
        {
        
            Stat_CustomersList.Add(x);

        }

        internal void AddtoEmployees(Employee x)
        {

            Stat_EmployeeLists.Add(x);

        }



        public void Logout()
        {
            LoggedInUser = null;
            LoggedInEmployee = null;
            IsCustomer = true;
            
        }

        public Statistics()
        {

        }
     

        internal void CustomersList()
        {

            List<Customer> ListofCustomers = new List<Customer>();
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Customer.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                Customer Customer = new Customer(arrays[0], arrays[1], arrays[2], arrays[3], arrays[4], Convert.ToString(arrays[5]), arrays[6], Convert.ToDateTime(arrays[7]));
                ListofCustomers.Add(Customer);
            }

            Stat_CustomersList = ListofCustomers;
            
        }

        internal void EmployeeList()
        {

            List<Employee> ListofEmployees = new List<Employee>();
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/Employees.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                Employee employee= new Employee(arrays[0], arrays[1], arrays[2], arrays[3], arrays[4], Convert.ToString(arrays[5]), arrays[6], Convert.ToDateTime(arrays[7]));
                ListofEmployees.Add(employee);
            }
           
            Stat_EmployeeLists = ListofEmployees;
            
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

       public bool UserExists(string username)
        {
            List<Employee> Employees = Stat_EmployeeLists;
            List<Customer> Customers = Stat_CustomersList;

            foreach (Customer user in Customers)
            {
                if (user.Username == username)
                { 
                   return true;
                }
            }

            foreach (Employee emplo in Employees)
            {
                if (emplo.Username == username)
                {
                    return true;
                }
            }
            return false;
        }


        public bool Authenticate(string username, string password)
        {

            
            foreach(Customer user in Stat_CustomersList)
            {
                if(user.Username == username && user.Password == password)
                {
                    Statistics.LoggedInUser = Stat_CustomersList.Find(Customer => Customer.Username.Contains(username) && Customer.Password.Contains(password));
                    Statistics.Userloggedin = LoggedInUser.Username;
                    LoggedInUser.OwnedGame = GetOwnedGames(LoggedInUser);

                    return true;
                }
            }

            foreach (Employee emplo in Stat_EmployeeLists)
            {
                if (emplo.Username == username && emplo.Password == password)
                {
                    Statistics.LoggedInEmployee = Stat_EmployeeLists.Find(Employee => Employee.Username.Contains(username) && Employee.Password.Contains(password));
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
            List<Customer> lista = Stat_CustomersList;
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

        public string GetEmail(string user)
        {
            foreach(Customer cust in Stat_CustomersList)
            {
                if(cust.Username == user)
                {
                    return cust.Email;
                }
            }

            return "false";
        }

        public void ListofNews()
        {
            List<News> List = new List<News>();
            string[] mydocument = System.IO.File.ReadAllLines(@"Assets/News.txt");

            foreach (string line in mydocument)
            {
                string[] arrays = line.Split(Convert.ToChar(";"));
                News news = new News(arrays[0], arrays[1], Convert.ToDateTime(arrays[2]));
                NewsList.Add(news);
            }
            
        }

    }
}
