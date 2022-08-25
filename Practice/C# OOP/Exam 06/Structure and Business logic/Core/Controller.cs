using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private FormulaOneCarRepository carRepository;
        private RaceRepository raceRepository;
        private PilotRepository pilotRepository;

       
        public Controller()
        {
            carRepository = new FormulaOneCarRepository();
            raceRepository = new RaceRepository();
            pilotRepository = new PilotRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
         
            var car = carRepository.models.FirstOrDefault(c => c.Model == carModel);
            var pilot = pilotRepository.pilots.FirstOrDefault(p => p.FullName == pilotName);

            if (car == null)
            {
                throw new NullReferenceException(String.Format("Car {0} does not exist.", carModel));
            }

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format("Pilot {0} does not exist or has a car.", pilotName));
            }

            pilot.AddCar(car);

            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var pilot = pilotRepository.pilots.FirstOrDefault(p => p.FullName == pilotFullName);
            var race = raceRepository.races.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format("Race {0} does not exist.", raceName));
            }

            if (pilot == null)
            {
                throw new InvalidOperationException(String.Format("Can not add pilot {0} to the race.", pilotFullName));
            }

            if (pilot.CanRace == false || race.Pilots.Any(pilot => pilot.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format("Can not add pilot {0} to the race.", pilotFullName));
            }

            race.Pilots.Add(pilot); 

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);

            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format("Formula one car type {0} is not valid.", type));
            }

            if (carRepository.models.Any(car => car.Model == model))
            {

                throw new InvalidOperationException(String.Format("Formula one car {0} is already created.", model));
              
            }
            else
            {
                carRepository.models.Add(car);
                return $"Car {type}, model {model} is created.";
            }
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = new Pilot(fullName);

            if (pilotRepository.pilots.Any(item => item.FullName == fullName))
            {
                throw new InvalidOperationException(String.Format("Pilot {0} is already created.", fullName));
            }
            else
            {
                pilotRepository.pilots.Add(pilot);
                return $"Pilot {fullName} is created.";
            }
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            Race race = new Race(raceName, numberOfLaps);

            if (raceRepository.races.Any(race => race.RaceName == raceName))
            {
                throw new InvalidOperationException(String.Format("Race {0} is already created.", raceName));
            }
            else
            {
                raceRepository.races.Add(race);
                return $"Race {raceName} is created.";
            }
        }

        public string PilotReport()
        {
            var orderedPilots = pilotRepository.pilots.OrderByDescending(p => p.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < orderedPilots.Count; i++)
            {
                if (i == orderedPilots.Count - 1)
                {
                    sb.Append(orderedPilots[i].ToString());
                    break;
                }
                sb.AppendLine(orderedPilots[i].ToString());
            }
            return sb.ToString();
        }

        public string RaceReport()
        {
            
            var executedRaces = raceRepository.races.FindAll(r => r.TookPlace == true).ToList();
           
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < executedRaces.Count; i++)
            {
                if (i == executedRaces.Count - 1)
                {
                    sb.Append(executedRaces[i].RaceInfo());
                    break;
                }
                sb.AppendLine(executedRaces[i].RaceInfo());
            }
            
            return sb.ToString();
        
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.races.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format("Race {0} does not exist.", raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(String.Format("Can not execute race {0}.", raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format("Race {0} cannot start with less than three participants.", raceName));
            }

            var top3pilots = pilotRepository.pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            race.TookPlace = true;

            var winner = top3pilots.First();
            winner.WinRace();

            return $"Pilot {winner.FullName} wins the {raceName} race.{Environment.NewLine}Pilot {top3pilots[1].FullName} is second in the {raceName} race.{Environment.NewLine}Pilot {top3pilots[2].FullName} is third in the {raceName} race.";

        }
    }
}
