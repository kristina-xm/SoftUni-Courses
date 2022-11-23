namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        public const int combatExperienceIncrease = 10;
        private string fullName;

        private int combatExperience = 0;
        private List<IVessel> vessels;

        public Captain(string name)
        {
            this.FullName = name;
            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get { return combatExperience; }
            set { combatExperience = value; }
        }

        public ICollection<IVessel> Vessels => vessels;


        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += combatExperienceIncrease;
        }

        public string Report()
        {
            var output = $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.vessels.Count} vessels.";

            if (this.vessels.Count > 0)
            {
                var sb = new StringBuilder();

                for (int i = 0; i < vessels.Count; i++)
                {
                    if (i == vessels.Count - 1)
                    {
                        sb.Append(vessels[i].ToString());
                        break;
                    }
                    sb.AppendLine(vessels[i].ToString());
                }
                return $"{output}{Environment.NewLine}{sb.ToString()}";
            }
            else
            {
                return output;
            }
        }
    }
}
