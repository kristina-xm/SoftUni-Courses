using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        public List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            var pilot = this.pilots.FirstOrDefault(c => c.FullName == name);
            if (pilot == null)
            {
                return null;
            }
            return pilot;
        }

        public bool Remove(IPilot model)
        {
            if (this.pilots.Any(p => p.FullName == model.FullName))
            {
                this.pilots.Remove(model);
                return true;
            }
            return false;
        }
    }
}
