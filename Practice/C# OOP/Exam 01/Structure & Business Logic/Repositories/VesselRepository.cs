namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VesselRepository : IRepository<IVessel>
    {
        private  List<IVessel> vesselsCollection;

        public VesselRepository()
        {
            vesselsCollection = new List<IVessel>();
        }
        
        public IReadOnlyCollection<IVessel> Models => vesselsCollection;

        public void Add(IVessel model)
        {
            vesselsCollection.Add(model);
        }
        public bool Remove(IVessel model)
        {
            var vesselToRemove = vesselsCollection.FirstOrDefault(v => v.Name == model.Name);

            if (vesselToRemove != null)
            {
                vesselsCollection.Remove(vesselToRemove);
                return true;
            }
            return false;
        }

        public IVessel FindByName(string name)
        {
            var neededVessel = vesselsCollection.FirstOrDefault(v => v.Name == name);

            if (neededVessel != null)
            {
                return neededVessel;
            }
            else
            {
                return null;
            }
        }
        
    }
}
