using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Vehicle> vehicles = new List<Vehicle>();

            //MakingListOfReceivedVehicles(vehicles, input);
            while (input[0] != "End")
            {
                string typeOfVehicle = input[0].ToLower();
                string model = input[1];
                string color = input[2].ToLower();
                double horsePower = double.Parse(input[3]);

                Vehicle vehicle = new Vehicle(typeOfVehicle, model, color, horsePower);

                vehicles.Add(vehicle);

                input = Console.ReadLine().Split().ToArray();
            }

            string[] inputAfterEnd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Vehicle> catalogue = new List<Vehicle>();

            while (inputAfterEnd[0] != "Close")
            {

                string model = inputAfterEnd[0];

                if (vehicles.Any(v => v.Model == model))
                {
                    foreach (var vehicle in vehicles)
                    {
                        if (vehicle.Model == model)
                        {
                            Console.WriteLine(vehicle);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                inputAfterEnd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            HorsePowerOfCars(vehicles);
            HorsePowerOfTrucks(vehicles);

        }

        static void HorsePowerOfCars(List<Vehicle> vehicles)
        {
            double commonHorsePowerCars = 0;
            int numberOfCars = 0;
            string type = "Cars";

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == "Car")
                {
                    commonHorsePowerCars += vehicle.HorsePower;
                    numberOfCars++;
                }
                else
                {
                    continue;
                }
            }
            if (numberOfCars == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
                return;
            }
            double averageHorsePowerCars = commonHorsePowerCars / numberOfCars;

            Console.WriteLine($"{type} have average horsepower of: {averageHorsePowerCars:f2}.");
        }

        static void HorsePowerOfTrucks(List<Vehicle> vehicles)
        {
            double commonHorsePowerTrucks = 0;
            int numberOfTrucks = 0;
            string type = "Trucks";

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == "Truck")
                {
                    commonHorsePowerTrucks += vehicle.HorsePower;
                    numberOfTrucks++;
                }
                else
                {
                    continue;
                }
            }
            if (numberOfTrucks == 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
                return;
            }
            double averageHorsePowerTrucks = commonHorsePowerTrucks / numberOfTrucks;
            Console.WriteLine($"{type} have average horsepower of: {averageHorsePowerTrucks:f2}.");
        }
    }
}
