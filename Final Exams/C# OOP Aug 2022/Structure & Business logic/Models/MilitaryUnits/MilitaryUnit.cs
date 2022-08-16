namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public int EnduranceLevel => enduranceLevel;

        public void IncreaseEndurance()
        {
            enduranceLevel++;
            
            if (this.EnduranceLevel > 20)
            {
                enduranceLevel = 20;
                throw new ArgumentException(String.Format(ExceptionMessages.EnduranceLevelExceeded));
            }

        }
    }
}
