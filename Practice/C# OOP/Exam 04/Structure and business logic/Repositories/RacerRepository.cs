namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public RacerRepository()
        {

            racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => racers;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            racers.Add(model);
        }

        public IRacer FindBy(string property)
        {
            var racer = racers.FirstOrDefault(r => r.Username == property);

            if (racer == null)
            {
                return null;
            }
            return racer;
        }

        public bool Remove(IRacer model)
        {
            var racer = racers.FirstOrDefault(r => r.Username == model.Username);

            if (racer != null)
            {
                racers.Remove(racer);
                return true;
            }
            return false;
        }
    }
}
