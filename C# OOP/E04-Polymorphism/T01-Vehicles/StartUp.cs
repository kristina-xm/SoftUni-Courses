namespace Vehicles
{
    using System;
    using Vehicles.Core;
    using Vehicles.Factories;
    using Vehicles.Factories.Interfaces;
    using Vehicles.Models;
    using Vehicles.Models.Interfaces;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            IVehicleFactory vehicleFactory = new VehicleFactory();

            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));

            Vehicle truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
