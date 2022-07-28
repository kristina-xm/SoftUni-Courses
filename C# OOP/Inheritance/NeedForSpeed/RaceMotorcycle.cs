using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        const double DefaultFuelConsumption = 8;
        public override double FuelConsumption => DefaultFuelConsumption;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
}
