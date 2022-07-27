using System;
using System.Collections.Generic;

namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstCommand = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();

            while (firstCommand != "Sail")
            {
                string[] commandArgs = firstCommand.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string cityName = commandArgs[0];
                int population = int.Parse(commandArgs[1]);
                int gold = int.Parse(commandArgs[2]);

                if (cities.ContainsKey(cityName))
                {
                    cities[cityName].Population += population;
                    cities[cityName].Gold += gold;
                }
                else
                {
                    City newCity = new City(cityName, population, gold);
                    cities.Add(cityName, newCity);
                }

                firstCommand = Console.ReadLine();
            }

            string secondCommand = Console.ReadLine();
            while (secondCommand != "End")
            {
                string[] secondCmdArds = secondCommand.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string commandType = secondCmdArds[0];

                if (commandType == "Plunder")
                {
                    string townToPlunder = secondCmdArds[1];
                    int populationToRemove = int.Parse(secondCmdArds[2]);
                    int goldToSteal = int.Parse(secondCmdArds[3]);

                    cities[townToPlunder].Population -= populationToRemove;
                    cities[townToPlunder].Gold -= goldToSteal;

                    Console.WriteLine($"{townToPlunder} plundered! {goldToSteal} gold stolen, {populationToRemove} citizens killed.");

                    if (cities[townToPlunder].Population <= 0 || cities[townToPlunder].Gold <= 0)
                    {

                        Console.WriteLine($"{townToPlunder} has been wiped off the map!");
                        cities.Remove(townToPlunder);
                    }

                }
                else if (commandType == "Prosper")
                {
                    int goldToAdd = int.Parse(secondCmdArds[2]);
                    string townToProsper = secondCmdArds[1];

                    if (goldToAdd < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        secondCommand = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cities[townToProsper].Gold += goldToAdd;
                        Console.WriteLine($"{goldToAdd} gold added to the city treasury. {townToProsper} now has {cities[townToProsper].Gold} gold.");
                    }

                }
                secondCommand = Console.ReadLine();
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var kvp in cities)
                {
                    Console.WriteLine($"{kvp.Value.Name} -> Population: {kvp.Value.Population} citizens, Gold: {kvp.Value.Gold} kg");
                }
            }
        }
    }
}
