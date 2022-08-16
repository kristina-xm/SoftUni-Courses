﻿namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + this.FuelConsumptionModifier;
            }
        }

        protected override double FuelConsumptionModifier => CarFuelConsumptionIncrement;
    }
}
