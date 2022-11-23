using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        public List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => races;

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IRace FindByName(string name)
        {
            var race = this.races.FirstOrDefault(c => c.RaceName == name);
            if (race == null)
            {
                return null;
            }
            return race;
        }

        public bool Remove(IRace model)
        {
            if (this.races.Any(r => r.RaceName == model.RaceName))
            {
                this.races.Remove(model);
                return true;
            }
            return false;
        }
    }
}
