namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private CarRepository carsData;
        private RacerRepository racersData;
        private IMap map;

        public Controller()
        {
            carsData = new CarRepository();
            racersData = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }

            carsData.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException("Invalid racer type!");
            }

            IRacer racer = null;

            var car = carsData.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }

            racersData.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racersData.FindBy(racerOneUsername);
            var racerTwo = racersData.FindBy(racerTwoUsername);

            if (racerOne == null && racerTwo == null)
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            string result = map.StartRace(racerOne, racerTwo);

            return result;

        }

        public string Report()
        {
            var orderedList = racersData.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username).ToList();

            var sb = new StringBuilder();

            int count = 0;
            foreach (var racer in orderedList)
            {
                if (count == orderedList.Count - 1)
                {
                    sb.Append(racer.ToString());
                    break;
                }
                sb.AppendLine(racer.ToString());
                count++;
            }

            return sb.ToString();
        }
    }
}
