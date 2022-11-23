using System;
using System.Collections.Generic;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string brandCar = carInfo[0];
                double miles = double.Parse(carInfo[1]);
                double fuel = double.Parse(carInfo[2]);

                Car carProps = new Car(brandCar, miles, fuel);

                cars.Add(brandCar, carProps);
            }

            string[] commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Stop")
            {
                if (commands[0] == "Drive")
                {
                    string nameOfCar = commands[1];
                    double distance = double.Parse(commands[2]);
                    double fuel = double.Parse(commands[3]);

                    if (cars[nameOfCar].Fuel >= fuel)
                    {
                        cars[nameOfCar].Fuel -= fuel;
                        cars[nameOfCar].Mileage += distance;

                        Console.WriteLine($"{nameOfCar} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[nameOfCar].Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {nameOfCar}!");
                            cars.Remove(nameOfCar);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    string nameOfCar = commands[1];
                    double fuel = double.Parse(commands[2]); 

                    cars[nameOfCar].Fuel += fuel; 

                  

                    if (cars[nameOfCar].Fuel > 75) 
                    {
                        double exceededFuel = cars[nameOfCar].Fuel - 75; 
                        double actualFuelNeeded = fuel - exceededFuel; 
                        cars[nameOfCar].Fuel = 75;

                        Console.WriteLine($"{nameOfCar} refueled with {actualFuelNeeded} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfCar} refueled with {fuel} liters");
                    }
                }
                else if (commands[0] == "Revert")
                {
                    string nameOfCar = commands[1];
                    double kilometers = double.Parse(commands[2]);

                    cars[nameOfCar].Mileage -= kilometers;

                    if (cars[nameOfCar].Mileage < 10000)
                    {
                        cars[nameOfCar].Mileage = 10000;
                        commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    Console.WriteLine($"{nameOfCar} mileage decreased by {kilometers} kilometers");


                }

                commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var kvp in cars)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value.Mileage} kms, Fuel in the tank: {kvp.Value.Fuel} lt.");
            }
        }
    }
}
