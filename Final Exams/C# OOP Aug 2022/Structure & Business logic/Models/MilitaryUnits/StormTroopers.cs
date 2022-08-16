namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class StormTroopers : MilitaryUnit
    {
        private const double cost = 2.5;
        public StormTroopers() : base(cost)
        {
        }
    }
}
