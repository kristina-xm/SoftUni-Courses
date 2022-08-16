namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double cost = 30;
        public AnonymousImpactUnit() : base(cost)
        {
        }
    }
}
