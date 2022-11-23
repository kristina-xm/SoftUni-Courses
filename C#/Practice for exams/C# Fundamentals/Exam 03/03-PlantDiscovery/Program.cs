using System;
using System.Collections.Generic;

namespace PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plantCollection = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plantName = info[0];
                double rarity = double.Parse(info[1]);

                var plant = new Plant(rarity);

                plantCollection.Add(plantName, plant);
            }

            string[] cmds = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);


            while (cmds[0] != "Exhibition")
            {
                if (cmds[0] == "Rate")
                {
                    string[] plantRating = cmds[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plantName = plantRating[0];
                    if (!plantCollection.ContainsKey(plantName))
                    {
                        Console.WriteLine("error");
                        cmds = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    double rating = double.Parse(plantRating[1]);

                    plantCollection[plantName].RatingList.Add(rating);

                }
                else if (cmds[0] == "Update")
                {
                    string[] plantNewRarity = cmds[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plantName = plantNewRarity[0];
                    if (!plantCollection.ContainsKey(plantName))
                    {
                        Console.WriteLine("error");
                        cmds = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    double newRarity = double.Parse(plantNewRarity[1]);
                    plantCollection[plantName].Rarity = newRarity;
                }
                else if (cmds[0] == "Reset")
                {
                    string[] resetPlant = cmds[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string plantName = resetPlant[0];
                    if (!plantCollection.ContainsKey(plantName))
                    {
                        Console.WriteLine("error");
                        cmds = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    plantCollection[plantName].RatingList.Clear();
                }

                cmds = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var kvp in plantCollection)
            {
                double sum = 0;
                int count = 0;
                foreach (var item in kvp.Value.RatingList)
                {

                    sum += item;
                    count++;
                }
                double averageSum = 0;
                if (kvp.Value.RatingList.Count == 0)
                {
                    averageSum = 0;
                    Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.Rarity}; Rating: {averageSum:f2}");
                    continue;
                }
                averageSum = sum / count;
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.Rarity}; Rating: {averageSum:f2}");
            }
    }
}
