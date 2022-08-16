using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelIncrement = 1.6;
        private const double RefuelCoefficient = 0.95;
       
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        protected override double FuelConsumptionModifier => TruckFuelIncrement;

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + this.FuelConsumptionModifier;
        }


        public override void Refuel(double liters)
        {
            base.Refuel(liters * RefuelCoefficient);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
