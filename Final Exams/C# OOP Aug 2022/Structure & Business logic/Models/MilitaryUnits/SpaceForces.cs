namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SpaceForces : MilitaryUnit
    {
        private const double cost = 11;
        public SpaceForces() : base(cost)
        {
        }
    }
}
