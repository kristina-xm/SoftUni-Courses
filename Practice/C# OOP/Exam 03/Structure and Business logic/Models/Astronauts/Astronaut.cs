namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {

        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return oxygen;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }

        public virtual bool CanBreath => Oxygen > 0 ? true : false;

        public IBag Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public virtual void Breath()
        {
            this.Oxygen -= 10;
            if (this.Oxygen <= 0)
            {
                this.Oxygen = 0;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");

            if (this.Bag.Items.Count == 0)
            {
                sb.Append("Bag items: none");
            }
            else
            {
                sb.Append($"Bag items: {string.Join(", ", this.Bag.Items)}");
            }

            return sb.ToString();
        }
    }
}
