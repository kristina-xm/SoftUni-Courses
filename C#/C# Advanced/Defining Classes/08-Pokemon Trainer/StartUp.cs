using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
           
            var trainers = new Dictionary<string, Trainer>();
            List<Trainer> trainersList = new List<Trainer>(); 

            while (info[0] != "Tournament")
            {
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                double pokemonHealth = double.Parse(info[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    PokemonList pokemonList = new PokemonList();
                    pokemonList.AddPokemon(pokemon);
                    
                    Trainer trainer = new Trainer(trainerName, 0, pokemonList);
                    trainers.Add(trainerName, trainer);
                    
                }
                else
                {
                    Trainer trainer = trainers[trainerName];
                    trainer.PokemonCollection.AddPokemon(pokemon);

                }


               info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string cmds = Console.ReadLine();

            while (cmds != "End")
            {
                if (cmds == "Fire")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainers[trainer.Key].PokemonCollection.Pokemons.Any(x => x.Element == "Fire"))
                        {
                            trainers[trainer.Key].Badgets++;
                        }
                        else
                        {
                            for (int i = 0; i < trainers[trainer.Key].PokemonCollection.Pokemons.Count; i++)
                            {
                                trainers[trainer.Key].PokemonCollection.Pokemons[i].Health -= 10;
                            }

                            trainers[trainer.Key].PokemonCollection.Pokemons.RemoveAll(x => x.Health <= 0);
                        }
                    }
                    
                }
                else if (cmds == "Water")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainers[trainer.Key].PokemonCollection.Pokemons.Any(x => x.Element == "Water"))
                        {
                            trainers[trainer.Key].Badgets++;
                        }
                        else
                        {
                            int countOfPokemons = trainers[trainer.Key].PokemonCollection.Pokemons.Count;

                            for (int i = 0; i < countOfPokemons; i++)
                            {
                                trainers[trainer.Key].PokemonCollection.Pokemons[i].Health -= 10;
                            }
                            trainers[trainer.Key].PokemonCollection.Pokemons.RemoveAll(x => x.Health <= 0);
                        }
                    }
                }
                else if (cmds == "Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainers[trainer.Key].PokemonCollection.Pokemons.Any(x => x.Element == "Electricity"))
                        {
                            trainers[trainer.Key].Badgets++;
                        }
                        else
                        {
                            for (int i = 0; i < trainers[trainer.Key].PokemonCollection.Pokemons.Count; i++)
                            {
                                trainers[trainer.Key].PokemonCollection.Pokemons[i].Health -= 10;
                            }
                            trainers[trainer.Key].PokemonCollection.Pokemons.RemoveAll(x => x.Health <= 0);
                        }
                    }
                }

                cmds = Console.ReadLine();
            }

           var sortedDict = trainers.OrderByDescending(tr => tr.Value.Badgets);

            foreach (var item in sortedDict)
            {
                Console.WriteLine($"{item.Key} {item.Value.Badgets} {item.Value.PokemonCollection.Pokemons.Count}");
            }
     
        }
    }
}
