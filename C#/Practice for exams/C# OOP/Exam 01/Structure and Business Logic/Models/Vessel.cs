namespace NavalVessels.Models
{
    using System;
    using NavalVessels.Models.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {

            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            targets = new List<string>();
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
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get
            {
                return captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                this.captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public ICollection<string> Targets
        {
            get { return targets; }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);
        }

        public void RepairVessel()
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            if (this.Targets.Count == 0)
            {
                sb.Append(" *Targets: None");
            }
            else
            {
                sb.Append($" *Targets: {string.Join(", ", Targets)}");
            }
            
            return sb.ToString();

        }
    }
}
