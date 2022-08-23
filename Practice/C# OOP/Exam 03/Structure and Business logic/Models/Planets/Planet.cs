namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;
        public List<string> items;

        public Planet(string name)
        {
            this.Name = name;
            items = new List<string>();
        }
        public ICollection<string> Items => items;

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
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }
    }
}
