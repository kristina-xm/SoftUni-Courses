namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private HashSet<IMilitaryUnit> units;
       
        public UnitRepository()
        {
            units = new HashSet<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            var unitToFind = units.FirstOrDefault(w => w.GetType().Name == name);

            if (unitToFind != null)
            {
                return unitToFind;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var unitToRemove = units.FirstOrDefault(w => w.GetType().Name == name);

            if (unitToRemove != null)
            {
                units.Remove(unitToRemove);
                return true;
            }
            return false;
        }
    }
}
