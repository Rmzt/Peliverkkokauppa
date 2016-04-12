using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    public class Statistics
    {
        public Dictionary<int,Game> ListOfGames { get; set; }
        public Dictionary<string, Developer> ListOfDevelopers { get; set; }

    }
}
