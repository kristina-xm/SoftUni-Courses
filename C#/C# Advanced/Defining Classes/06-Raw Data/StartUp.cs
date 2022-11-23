using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split().ToArray();

                string model = carData[0];

                double engineSpeed = double.Parse(carData[1]);
                double enginePower = double.Parse(carData[2]);
                EngineClass engine = new EngineClass(engineSpeed, enginePower);

                double cargoWeight = double.Parse(carData[3]);
                string cargoType = carData[4];
                CargoClass cargo = new CargoClass(cargoType, cargoWeight);

                TiresCollection tiresCollection = new TiresCollection();

                double tire1Pressure = double.Parse(carData[5]);
                double tire1Age = double.Parse(carData[6]);
                TireClass tire = new TireClass(tire1Pressure, tire1Age);
                tiresCollection.AddTire(tire);


                double tire2Pressure = double.Parse(carData[7]);
                double tire2Age = double.Parse(carData[8]);
                TireClass tire2 = new TireClass(tire2Pressure, tire2Age);
                tiresCollection.AddTire(tire2);


                double tire3Pressure = double.Parse(carData[9]);
                double tire3Age = double.Parse(carData[10]);
                TireClass tire3 = new TireClass(tire3Pressure, tire3Age);
                tiresCollection.AddTire(tire3);


                double tire4Pressure = double.Parse(carData[11]);
                double tire4Age = double.Parse(carData[12]);
                TireClass tire4 = new TireClass(tire4Pressure, tire4Age);
                tiresCollection.AddTire(tire4);


                Car car = new Car(model, engine, cargo, tiresCollection);
                cars.Add(car);

            }

            string finalCmd = Console.ReadLine();

            if (finalCmd == "fragile")
            {
                List<Car> pickedCars = new List<Car>();

                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "fragile")
                    {
                        foreach(var item in car.Tires.TiresList)
                        {
                            if (item.Pressure < 1)
                            {
                                pickedCars.Add(car);
                                break;
                               
                            }
                        }

                    }
                }

                foreach (var car in pickedCars)
                {
                    Console.WriteLine(car.Model);
                }
               
            }
            else if (finalCmd == "flammable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
