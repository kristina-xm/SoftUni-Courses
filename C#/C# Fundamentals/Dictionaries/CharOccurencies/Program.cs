using System;
using System.Collections.Generic;
using System.Linq;

namespace charOccurencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //text: t -> 2, e -> 1, x -> 1

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<char, int> occurrencies = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                string word = input[i];
                char[] chars = word.ToCharArray();

                foreach (var letter in chars)
                {
                    if (!occurrencies.ContainsKey(letter))
                    {
                        occurrencies.Add(letter, 0);
                    }
                    occurrencies[letter] += 1;
                }
            }

            foreach (var item in occurrencies)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
