using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class TireClass
    {
        public TireClass(double pressure, double age)
        {
            Age = age;
            Pressure = pressure;

        }
        private double age;
        private double pressure;

        public double Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

    }
}
