using System;

namespace Character-ASCII-Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string str1 = input[0];
            string str2 = input[1];

            int minLength = Math.Min(str1.Length, str2.Length);
            int maxLength = Math.Max(str1.Length, str2.Length);
            int sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += MultiplyCharsASCII(str1[i], str2[i]);
            }

            if (str1.Length != str2.Length)
            {
                string longerInput = str1.Length > str2.Length ? longerInput = str1 : longerInput = str2;
                for (int i = minLength; i < maxLength; i++)
                {
                    sum += longerInput[i];
                }
            }
            Console.WriteLine(sum);
        }

        static int MultiplyCharsASCII(char letter1, char letter2)
        {
            int multiply = letter1 * letter2;
            return multiply;
        }
    }
}
