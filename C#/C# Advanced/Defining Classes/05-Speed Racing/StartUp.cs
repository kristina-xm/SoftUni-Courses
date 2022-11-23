using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 1; i <= n; i++)
            {
                string data = Console.ReadLine();
                string model = data.Split()[0];
                double fuelAmount = double.Parse(data.Split()[1]);
                double fuelConsumption = double.Parse(data.Split()[2]);


                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string carModel = cmd.Split()[1];
                double amountOfKm = double.Parse(cmd.Split()[2]);

                Car carToDrive = cars.First(car => car.Model == carModel);
                carToDrive.Drive(amountOfKm);

                cmd = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
