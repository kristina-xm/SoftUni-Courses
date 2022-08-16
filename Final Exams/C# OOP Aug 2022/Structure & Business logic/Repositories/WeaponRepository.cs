namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private HashSet<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new HashSet<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weaponToFind = weapons.FirstOrDefault(w => w.GetType().Name == name);

            if (weaponToFind != null)
            {
                return weaponToFind;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var weaponToRemove = weapons.FirstOrDefault(w => w.GetType().Name == name);

            if (weaponToRemove != null)
            {
                weapons.Remove(weaponToRemove);
                return true;
            }
            return false;
        }
    }
}
