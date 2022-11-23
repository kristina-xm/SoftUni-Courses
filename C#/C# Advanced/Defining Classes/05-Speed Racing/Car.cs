using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TravelledDistance = 0;
        }

        public string Model { get; set; }
      
        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TravelledDistance { get; set; }


        public void Drive(double amountOfKm)
        {
            double neededLiters = amountOfKm * FuelConsumption;
           
            if (FuelAmount >= neededLiters)
            {
                FuelAmount -= neededLiters;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
