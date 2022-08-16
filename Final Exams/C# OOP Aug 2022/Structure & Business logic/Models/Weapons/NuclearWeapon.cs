namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class NuclearWeapon : Weapon
    {
        private const double price = 15;
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, price)
        {
        }
    }
}
