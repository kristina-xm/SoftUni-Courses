using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesCatalogue2
{
    public class Catalogue
    {
        public Catalogue()
        {
            this.Truck = new List<Truck>();
            this.Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }

        public List<Truck> Truck { get; set; }
        public object Trucks { get; internal set; }
    }
}
