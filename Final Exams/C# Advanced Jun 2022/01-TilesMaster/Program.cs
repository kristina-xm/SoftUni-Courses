using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> areasWhite = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> areasGrey = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            areasWhite.Reverse();

            var tupleList = new List<Tuple<string, int>>
            {
                 Tuple.Create("Sink", 40 ),
                 Tuple.Create("Oven", 50 ),
                 Tuple.Create("Countertop", 60 ),
                 Tuple.Create("Wall", 70)

            };

            Dictionary<string, int> areas = new Dictionary<string, int>()
            {
                {"Sink", 0 },
                {"Oven", 0 },
                {"Countertop", 0 },
                {"Wall", 0 },
                {"Floor", 0 }
            };

            bool forFloor = false;
            while (true)
            {
                if (areasWhite.Count <= 0 || areasGrey.Count <= 0)
                {
                    break;
                }

                var white = areasWhite[0];
                var grey = areasGrey[0];

                if (white == grey)
                {
                    var newTile = white + grey;

                    foreach (var item in tupleList)
                    {
                        forFloor = true;
                        if (item.Item2 == newTile)
                        {
                            forFloor = false;
                            areas[item.Item1]++;
                            areasWhite.Remove(white);
                            areasGrey.Remove(grey);
                            if (areasWhite.Count <= 0 || areasGrey.Count <= 0)
                            {
                                break;
                            }
                            break;
                        }

                    }

                    if (forFloor)
                    {
                        areas["Floor"]++;
                        areasWhite.Remove(white);
                        areasGrey.Remove(grey);
                        if (areasWhite.Count <= 0 || areasGrey.Count <= 0)
                        {
                            break;
                        }
                    }

                }
                else if (white != grey)
                {
                    areasWhite.Remove(white);
                    white /= 2;

                    areasWhite.Insert(0, white);
                    areasGrey.Remove(grey);
                    areasGrey.Add(grey);

                    var newWhite = white;
                    var newGrey = areasGrey[0];

                }
            }

            if (areasWhite.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", areasWhite)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (areasGrey.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", areasGrey)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var area in areas.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (area.Value > 0)
                {
                    Console.WriteLine($"{area.Key}: {area.Value}");
                }
            }
        }
    }
}
