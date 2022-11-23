using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Pokemon
    {
        private string name;
        private string element;
        private double health;

        public Pokemon(string name, string element, double health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Element
        {
            get { return element; }
            set { element = value; }
        }
        public double Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}
