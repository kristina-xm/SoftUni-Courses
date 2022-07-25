using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersOccurencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rawInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<double> numbers = rawInput.Select(number => double.Parse(number)).ToList();

            SortedDictionary<double, int> occurencies = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (occurencies.ContainsKey(number))
                {
                    occurencies[number] += 1;
                }
                else
                {
                    occurencies.Add(number, 1);
                }
            }

            foreach (var item in occurencies)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
