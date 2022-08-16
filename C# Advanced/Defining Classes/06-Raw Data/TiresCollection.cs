using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class TiresCollection
    {
        private List<TireClass> tires;

        public List<TireClass> TiresList
        {
            get { return tires; }
            set { tires = value; }
        }

        public TiresCollection()
        {
            this.tires = new List<TireClass>();

        }

        public void AddTire(TireClass tire)
        {
            this.tires.Add(tire);
            
        }

    }
}
