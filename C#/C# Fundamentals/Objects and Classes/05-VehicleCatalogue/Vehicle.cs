using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, double horsePower)
        {
            this.Type = UppercaseFirst(type);
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;

        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        static string UppercaseFirst(string type)
        {

            if (string.IsNullOrEmpty(type))
            {
                return string.Empty;
            }

            return char.ToUpper(type[0]) + type.Substring(1);
        }

        public override string ToString()
        {
            return $"Type: {this.Type}\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.HorsePower}";
        }
    }
}
