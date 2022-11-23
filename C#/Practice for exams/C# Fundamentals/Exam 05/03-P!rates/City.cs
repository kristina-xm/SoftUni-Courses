using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_rates
{
    public class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
