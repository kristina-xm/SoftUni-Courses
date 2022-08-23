namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SuperCar : Car
    {
        private const double initialFuelAvailable = 80;
        private const double fuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, initialFuelAvailable, fuelConsumptionPerRace)
        {
        }
    }
}
