using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int numOfEngines = int.Parse(Console.ReadLine());
            List<EngineClass> engines = new List<EngineClass>();
            List<Car> cars = new List<Car>();   

            for (int i = 0; i < numOfEngines; i++)
            {
                string[] engineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (engineInput.Length == 2)
                {
                    string model = engineInput[0];
                    int power = int.Parse(engineInput[1]);
                    EngineClass engine = new EngineClass(model, power);
                    engines.Add(engine);
                }
                else if(engineInput.Length == 3)
                {
                    string model = engineInput[0];
                    int power = int.Parse(engineInput[1]);
                    string thirdElement = engineInput[2];

                    string pattern = @"[A-Z]";

                    if (Regex.IsMatch(thirdElement, pattern))
                    {
                        EngineClass engine = new EngineClass(model, power, thirdElement);
                        engines.Add(engine);
                    }
                    else
                    {
                        int displacement = int.Parse(engineInput[2]);
                        EngineClass engine = new EngineClass(model, power, displacement);
                        engines.Add(engine);
                    }
                   
                }
                else if (engineInput.Length > 3)
                {
                    string model = engineInput[0];
                    int power = int.Parse(engineInput[1]);
                    int displacement = int.Parse(engineInput[2]);
                    string efficiency = engineInput[3];
                    EngineClass engine = new EngineClass(model, power, displacement, efficiency);
                    engines.Add(engine);
                }

            }

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] carInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (carInput.Length == 2)
                {
                    string carModel = carInput[0];
                    string carEngine = carInput[1];
                    EngineClass realCarEngine = engines.First(e => e.EngineModel == carEngine);

                    Car car = new Car(carModel, realCarEngine);
                    cars.Add(car);
                }
                else if(carInput.Length == 3)
                {
                    string carModel = carInput[0];
                    string carEngine = carInput[1];
                    EngineClass realCarEngine = engines.First(e => e.EngineModel == carEngine);
                    string thirdElement = carInput[2];
                    string pattern = @"[A-Z][a-z]+";
                    
                    //Regex carRegex = new Regex(@"[A-Z][a-z]+");

                    if (Regex.IsMatch(thirdElement, pattern))
                    {
                        Car car = new Car(carModel, realCarEngine, thirdElement);
                        cars.Add(car);
                    }
                    else
                    {
                        int weight = int.Parse(carInput[2]);
                        Car car = new Car(carModel, realCarEngine, weight);
                        cars.Add(car);
                    }
                    
                }
                else if (carInput.Length > 3)
                {
                    string carModel = carInput[0];
                    string carEngine = carInput[1];
                    EngineClass realCarEngine = engines.First(e => e.EngineModel == carEngine);
                    int weight = int.Parse(carInput[2]);
                    string color = carInput[3];
                    Car car = new Car(carModel, realCarEngine, weight, color);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                if (car.Weight == 0 && car.Engine.Displacement == 0)
                {
                    
                    Console.WriteLine($"{car.Model}:" +
                    $"\n  {car.Engine.EngineModel}:" +
                    $"\n    Power: {car.Engine.Power}" +
                    $"\n    Displacement: n/a" +
                    $"\n    Efficiency: {car.Engine.Efficiency}" +
                    $"\n  Weight: n/a" +
                    $"\n  Color: {car.Color}");
                    continue;
                }
                else if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"{car.Model}:" +
                   $"\n  {car.Engine.EngineModel}:" +
                   $"\n    Power: {car.Engine.Power}" +
                   $"\n    Displacement: n/a" +
                   $"\n    Efficiency: {car.Engine.Efficiency}" +
                   $"\n  Weight: {car.Weight}" +
                   $"\n  Color: {car.Color}");
                    continue;
                }
                else if (car.Weight == 0)
                {
                    Console.WriteLine($"{car.Model}:" +
                    $"\n  {car.Engine.EngineModel}:" +
                    $"\n    Power: {car.Engine.Power}" +
                    $"\n    Displacement: {car.Engine.Displacement}" +
                    $"\n    Efficiency: {car.Engine.Efficiency}" +
                    $"\n  Weight: n/a" +
                    $"\n  Color: {car.Color}");
                    continue;
                }

                Console.WriteLine($"{car.Model}:" +
                    $"\n  {car.Engine.EngineModel}:" +
                    $"\n    Power: {car.Engine.Power}" +
                    $"\n    Displacement: {car.Engine.Displacement}" +
                    $"\n    Efficiency: {car.Engine.Efficiency}" +
                    $"\n  Weight: {car.Weight}" +
                    $"\n  Color: {car.Color}");
            }
        }
    }
}
