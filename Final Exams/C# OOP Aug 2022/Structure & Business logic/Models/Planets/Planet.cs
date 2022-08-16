namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository armies;
        private WeaponRepository weapons;


        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            armies = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlanetName));
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidBudgetAmount));
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return CalculationOfMilitaryPower(); }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => armies.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.armies.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");

            if (this.Army.Count != 0)
            {
                sb.AppendLine($"--Forces: {string.Join(", ", this.armies.Models.Select(a => a.GetType().Name).ToList())}");
            }
            else
            {
                sb.AppendLine($"--Forces: No units");
            }

            if (this.Weapons.Count != 0)
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", this.weapons.Models.Select(w => w.GetType().Name).ToList())}");
               
            }
            else
            {
                sb.AppendLine("--Combat equipment: No weapons");
               
            }
            sb.Append($"--Military Power: {this.MilitaryPower}");


            return sb.ToString();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnsufficientBudget));
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in this.armies.Models)
            {
                item.IncreaseEndurance();
            }
        }

        private double CalculationOfMilitaryPower()
        {
            double sumOfUnitEndurances = 0;

            foreach (var item in Army)
            {
                sumOfUnitEndurances += item.EnduranceLevel;
            }

            double sumOfWeaponDesctructionLevels = 0;

            foreach(var item in Weapons)
            {
                sumOfWeaponDesctructionLevels += item.DestructionLevel;
            }

            var totalAmount = sumOfUnitEndurances + sumOfWeaponDesctructionLevels;

            if (this.Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3; 
            }
           
            if (this.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
