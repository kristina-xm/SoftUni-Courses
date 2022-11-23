namespace Easter.Repositories
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => eggs;

        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public IEgg FindByName(string name) => eggs.FirstOrDefault(e => e.Name == name);

        public bool Remove(IEgg model)
        {
            var eggToRemove = eggs.FirstOrDefault(e => e.Name == model.Name); 

            if (eggToRemove != null)
            {
                eggs.Remove(eggToRemove);
                return true;
            }
            return false;
        }
    }
}
