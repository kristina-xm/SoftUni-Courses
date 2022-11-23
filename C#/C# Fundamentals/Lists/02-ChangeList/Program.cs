using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "end")
            {
                if (commands[0] == "Delete")
                {
                    int element = int.Parse(commands[1]);
                    for (int i = 0; i < integers.Count; i++)
                    {
                        if (integers[i] == element)
                        {
                            integers.Remove(element);
                        }
                    } 
                }
                else if (commands[0] == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int positionIndex = int.Parse(commands[2]);

                    integers.Insert(positionIndex, element);
                }

                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
