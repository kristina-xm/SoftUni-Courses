using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> peopleInWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxNumberOfPeople = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] action = command.Split();

                if (action.Length > 1)
                {
                    int numberOfPassengers = int.Parse(action[1]);
                    peopleInWagons.Add(numberOfPassengers);
                }
                else if (action.Length == 1)
                {
                    int peopleToWagons = int.Parse(action[0]);
                    int indexOfItem = -1;
                    foreach (int item in peopleInWagons)
                    {
                        int currW = item;
                        indexOfItem++;
                        if (currW + peopleToWagons > maxNumberOfPeople)
                        {
                            continue;
                        }
                        else
                        {
                            currW += peopleToWagons;
                            peopleInWagons.Insert(indexOfItem, currW);
                            peopleInWagons.Remove(item);
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", peopleInWagons));
        }
    }
}
