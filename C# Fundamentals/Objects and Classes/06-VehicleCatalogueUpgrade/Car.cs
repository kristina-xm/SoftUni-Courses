using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesCatalogue2
{
    public class Car
    {
        public Car(string name, string model, int horsePower)
        {
            this.Brand = name;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }
}
