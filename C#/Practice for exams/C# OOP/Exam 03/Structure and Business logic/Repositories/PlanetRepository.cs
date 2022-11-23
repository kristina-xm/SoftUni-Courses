namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planets;

        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var planet = planets.FirstOrDefault(p => p.Name == name);

            if (planet != null)
            {
                return planet;
            }
            return null;
        }

        public bool Remove(IPlanet model)
        {
            var planet = planets.FirstOrDefault(p => p.Name == model.Name);

            if (planet != null)
            {
                planets.Remove(planet);
                return true;
            }
            return false;
        }
    }
}
