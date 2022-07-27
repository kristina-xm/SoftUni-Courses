using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car
    {

        public Car(string car, double miles, double fuel)
        {
            this.Brand = car;
            this.Mileage = miles;
            this.Fuel = fuel;
        }
        public string Brand { get; set; }
        public double Mileage { get; set; }
        public double Fuel { get; set; }

    }
}
