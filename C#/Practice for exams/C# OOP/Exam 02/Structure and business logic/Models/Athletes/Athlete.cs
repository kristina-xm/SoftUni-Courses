namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfmedals;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
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
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                fullName = value;
            }
        }

        public string Motivation
        {
            get
            {
                return motivation;
            }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                motivation = value;
            }
        }

        public int Stamina
        {
            get
            {
                return stamina;
            }
            set
            {
                stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return numberOfmedals;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                numberOfmedals = value;
            }
        }

        public abstract void Exercise();
    }
}
