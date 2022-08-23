namespace SpaceStation.Repositories
{
    using System;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using SpaceStation.Models.Astronauts.Contracts;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astros;

        public AstronautRepository()
        {
            astros = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => astros;

        public void Add(IAstronaut model)
        {
            this.astros.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            var astro = astros.FirstOrDefault(a => a.Name == name);

            if (astro != null)
            {
                return astro;
            }
            return null;
        }

        public bool Remove(IAstronaut model)
        {
            var astro = astros.FirstOrDefault(a => a.Name == model.Name);

            if (astro != null)
            {
                astros.Remove(astro);
                return true;
            }
            return false;
        }
    }
}
