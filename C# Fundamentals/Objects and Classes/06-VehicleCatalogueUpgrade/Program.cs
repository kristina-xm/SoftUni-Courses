using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesCatalogue2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogueObject = new Catalogue();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] arguments = command.Split('/', StringSplitOptions.RemoveEmptyEntries);

                string type = arguments[0];
                string brand = arguments[1];
                string model = arguments[2];
                int finalParameter = int.Parse(arguments[3]);

                if (type == "Car")
                {
                    Car newCar = new Car(brand, model, finalParameter);
                    catalogueObject.Cars.Add(newCar);
                }

                if (type == "Truck")
                {
                    Truck newTruck = new Truck(brand, model, finalParameter);
                    catalogueObject.Truck.Add(newTruck);
                }
                command = Console.ReadLine();
            }

            if (catalogueObject.Cars.Count > 0 )
            {
                Console.WriteLine("Cars:");

                List<Car> orderedCars = catalogueObject.Cars.OrderBy(car => car.Brand).ToList();

                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogueObject.Truck.Count > 0)
            {
                Console.WriteLine("Trucks:");

                List<Truck> orderedTrucks = catalogueObject.Truck.OrderBy(truck => truck.Brand).ToList();

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }

            }

        }
    }
}
