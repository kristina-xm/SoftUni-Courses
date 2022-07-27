using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDiscovery
{
    public class Plant
    {
        public Plant(double rarity)
        {
            this.Rarity = rarity;
            this.RatingList = new List<double>();
        }
        public double Rarity { get; set; }

        public List<double> RatingList { get; set; }
    }
}
