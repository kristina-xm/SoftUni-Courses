﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "motes", 0 },
                { "fragments", 0 }
                
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();

            string itemObtained = string.Empty;

            while (String.IsNullOrEmpty(itemObtained))
            {
                string materialsLine = Console.ReadLine().ToLower();

                string[] materialsArr = materialsLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                ProcessInputLines(keyMaterials, junk, materialsArr, ref itemObtained);
            }

            PrintOutput(itemObtained, keyMaterials, junk);
        }

        static void ProcessInputLines(Dictionary<string, int> keyMaterials, Dictionary<string, int> junk, string[] materialsArr, ref string itemObtained)
        {
            const int minCraftMaterialQty = 250;

            Dictionary<string, string> craftingTable = new Dictionary<string, string>
            {
                {"shards", "Shadowmourne" },
                {"fragments", "Valanyr" },
                {"motes", "Dragonwrath" },
            };

            for (int i = 0; i < materialsArr.Length; i += 2)
            {
                int currMaterialQty = int.Parse(materialsArr[i]);
                string currMaterial = materialsArr[i + 1];

                if (keyMaterials.ContainsKey(currMaterial))
                {
                    keyMaterials[currMaterial] += currMaterialQty;

                    if (keyMaterials[currMaterial] >= minCraftMaterialQty)
                    {
                        itemObtained = craftingTable[currMaterial];
                        keyMaterials[currMaterial] -= minCraftMaterialQty;
                        break;
                    }
                }
                else
                {
                    //The currmaterial is junk
                    if (!junk.ContainsKey(currMaterial))
                    {
                        junk[currMaterial] = 0;
                    }
                    junk[currMaterial] += currMaterialQty;
                }
            }
        }

        static void PrintOutput(string itemObtained, Dictionary<string,int>keyMaterialsLeft, Dictionary<string, int> junk)
        {
            Console.WriteLine($"{itemObtained} obtained!");

            foreach (var kvp in keyMaterialsLeft)
            {
                string keyMaterial = kvp.Key;
                int qtyLeft = kvp.Value;

                Console.WriteLine($"{keyMaterial}: {qtyLeft}");
            }

            foreach (var kvp in junk)
            {
                string junkMaterial = kvp.Key;
                int junkQty = kvp.Value;

                Console.WriteLine($"{junkMaterial}: {junkQty}");
            }
        }
    }
}
