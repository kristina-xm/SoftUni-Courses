namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {

        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private List<IPlanet> exploredPlanets;


        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            exploredPlanets = new List<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }

            astronauts.Add(astronaut);

            return $"Successfully added {type}: { astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }

            planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {

            List<IAstronaut> suitableAstronauts = new List<IAstronaut>();

            var planet = planets.Models.FirstOrDefault(p => p.Name == planetName);

            if (planet == null)
            {
                return null;
            }

            foreach (var astro in astronauts.Models)
            {
                if (astro.Oxygen > 60)
                {
                    suitableAstronauts.Add(astro);
                }
            }

            if (suitableAstronauts.Count() == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }

            var mission = new Mission();

            mission.Explore(planet, suitableAstronauts);

            var deadAstronauts = suitableAstronauts.Where(a => a.Oxygen == 0).ToList();

            exploredPlanets.Add(planet);

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts.Count} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");

            int count = -1;
            foreach (var astro in astronauts.Models)
            {
                count++;
                if (count == astronauts.Models.Count - 1)
                {
                    sb.Append(astro.ToString());
                    break;
                }
                sb.AppendLine(astro.ToString());

            }

            return sb.ToString();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astornautToRetire = astronauts.FindByName(astronautName);

            if (astornautToRetire == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astornautToRetire);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
