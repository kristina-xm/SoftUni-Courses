using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private HashSet<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new HashSet<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var planetToFind = planets.FirstOrDefault(p => p.Name == name);
            
            if (planetToFind != null)
            {
                return planetToFind;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var planetToRemove = planets.FirstOrDefault(p => p.Name == name);

            if (planetToRemove != null)
            {
                planets.Remove(planetToRemove);
                return true;
            }
            return false;
        }
    }
}
