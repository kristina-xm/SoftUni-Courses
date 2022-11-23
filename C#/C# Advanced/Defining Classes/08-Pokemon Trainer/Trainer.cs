using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Trainer
    {
        private string name;
        private int badgets;
        private PokemonList pokemonCollection;

        public Trainer(string name, int badgets, PokemonList pokemonCollection)
        {
            Name = name;
            Badgets = badgets;
            PokemonCollection = pokemonCollection;
        }

        public Trainer(string name, int badgets)
        {
            Name = name;
            Badgets = badgets;
           
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Badgets
        {
            get { return badgets; }
            set { badgets = value; }
        }

        public PokemonList PokemonCollection
        {
            get { return pokemonCollection; }
            set { pokemonCollection = value; }
        }
    }
}
