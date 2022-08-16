using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterChef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var tupleList = new List<Tuple<string, int>>
            {
                Tuple.Create( "Dipping sauce", 150 ),
                Tuple.Create( "Green salad", 250 ),
                Tuple.Create( "Chocolate cake", 300 ),
                Tuple.Create( "Lobster", 400 ),
            };

            Dictionary<string, int> cookedItems = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0 },
                {"Chocolate cake", 0 },
                {"Lobster", 0 }
            };


            while (true)
            {
                if (ingredients.Count <= 0 || freshness.Count() <= 0)
                {
                    break;
                }

                int ingredient = ingredients.Peek();
                int fresh = freshness.Peek();
                if (ingredient == 0)
                {
                    ingredients.Dequeue();
                    if (ingredients.Count <= 0 || freshness.Count() <= 0)
                    {
                        break;
                    }
                    continue;
                }

                int mix = ingredient * fresh;

                if (tupleList.Any(x => x.Item2 == mix))
                {
                    int index = tupleList.FindIndex(x => x.Item2 == mix);
                    var tuple = tupleList.ElementAt(index);
                    string dish = tuple.Item1;

                    cookedItems[dish]++;

                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    int increasedIngredient = ingredients.Dequeue();
                    increasedIngredient += 5;
                    ingredients.Enqueue(increasedIngredient);
                }
            }

            if (cookedItems.All(x => x.Value >= 1))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

                foreach (var item in cookedItems.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }

                foreach (var item in cookedItems.OrderBy(x => x.Key))
                {
                    if (item.Value >= 1)
                    {
                        Console.WriteLine($"# {item.Key} --> {item.Value}");
                    }

                }
            }
        }
    }
}
