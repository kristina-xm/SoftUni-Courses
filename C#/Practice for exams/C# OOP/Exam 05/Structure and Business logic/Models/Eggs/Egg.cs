namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using System;
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                name = value; 
            }
        }

        public int EnergyRequired
        {
            get { return energyRequired; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
               energyRequired = value;
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;

            if (this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            if (this.EnergyRequired > 0)
            {
                return false;  
            }
           return true;
        } 
    }
}
