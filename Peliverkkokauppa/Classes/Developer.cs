using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    public class Developer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }



        public Dictionary<int, Game> PublishedGames { get; set; }


        public Developer(string name, string address, string description, string email)
        {
            Name = name;
            Address = address;
            Description = description;
            Email = email;

            PublishedGames = new Dictionary<int, Game>();

            
        }

        public Developer()
        {
            PublishedGames = new Dictionary<int, Game>();
        }

        public void RemovePublishedGame(int i)
        {
            if (PublishedGames.ContainsKey(i))
            {
                PublishedGames.Remove(i);
            }
        }

        public void AddPublishedGame(int i, Game t)
        {
            PublishedGames.Add(i, t);
        }

      

    }
}
