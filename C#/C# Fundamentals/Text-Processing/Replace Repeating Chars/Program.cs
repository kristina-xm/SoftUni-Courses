using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> str = input.ToList();

            for (int i = 0; i < str.Count - 1; i++)
            {
                char current = str[i];
                char next = str[i + 1];
                if (current == next)
                {
                    str.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(string.Join("", str));
        }
    }
}
