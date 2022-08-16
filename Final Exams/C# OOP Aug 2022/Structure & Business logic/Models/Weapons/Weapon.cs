namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;

    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        public Weapon(int destructionLevel, double price)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int DestructionLevel
        {
            get { return destructionLevel; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooLowDestructionLevel));
                }
                else if (value > 10)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooHighDestructionLevel));
                }
                destructionLevel = value;
            }
        }
    }
}
