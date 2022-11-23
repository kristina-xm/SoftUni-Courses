using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesCatalogue2
{
    public class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;

        }
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }
}
