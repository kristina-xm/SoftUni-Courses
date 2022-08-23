using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {

        private const double initialFuelAvailable = 65;
        private const double fuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, initialFuelAvailable, fuelConsumptionPerRace)
        {

        }

        public override void Drive()
        {
            base.Drive();

            var horsePowerReducing = Math.Round(this.HorsePower * 0.03);

            this.HorsePower -= (int)horsePowerReducing;

        }
    }
}
