using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        const double DefaultFuelConsumption = 1.25;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
    }
}
