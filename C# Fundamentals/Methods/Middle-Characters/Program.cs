using System;

namespace Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintsCharacterInMiddle(input);

        }
        static void PrintsCharacterInMiddle(string input)
        {
            char[] chars = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                chars[i] = input[i];
            }

            if (chars.Length % 2 == 0)
            {
                Console.Write(chars[(chars.Length / 2) - 1]);
                Console.WriteLine(chars[chars.Length / 2]);

            }
            else
            {
                Console.WriteLine(chars[chars.Length / 2]);
            }
        }
    }
}
