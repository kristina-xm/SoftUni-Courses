namespace Easter.Models.Bunnies
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            dyes = new List<IDye>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public abstract void Work();

        public override string ToString()
        {
            var notFinishedDyes = this.Dyes.Where(d => !d.IsFinished()).ToList();

            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.Append($"Dyes: {notFinishedDyes.Count} not finished");

            return sb.ToString();
        }

    }
}
