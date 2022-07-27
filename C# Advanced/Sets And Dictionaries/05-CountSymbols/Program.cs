using System;
using System.Collections.Generic;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            char[] chars = text.ToCharArray();
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            for (int i = 0; i < chars.Length; i++)
            {
                int count = 0;

                if (dict.ContainsKey(chars[i]))
                {
                    continue;
                }
                for (int j = 0; j < chars.Length; j++)
                {
                    if (chars[i] == chars[j])
                    {
                        count++;
                    }
                }

                dict.Add(chars[i], count);
            }

            
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
