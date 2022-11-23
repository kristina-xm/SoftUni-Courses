using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        const double DefaultFuelConsumption = 3;

        //private double fuelConsumption;

        public override double FuelConsumption => DefaultFuelConsumption;
        
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
}
