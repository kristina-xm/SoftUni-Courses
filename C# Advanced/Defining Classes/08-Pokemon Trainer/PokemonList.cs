using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class PokemonList
    {
        private List<Pokemon> pokemons;

        public PokemonList()
        {
            this.pokemons = new List<Pokemon>();
        }
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);

        }
    }
}
