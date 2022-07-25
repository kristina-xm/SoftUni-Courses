using System;

namespace Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTopNumbersUpTo(number);
        }

        private static void PrintTopNumbersUpTo(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (CheckSumDivisible(i) && CheckOddDigit(i))
                    Console.WriteLine(i);
            }
        }

        private static bool CheckOddDigit(int number)
        {
            while (number > 0)
            {
                if ((number % 10) % 2 == 1)
                    return true;
                number /= 10;
            }

            return false;
        }

        private static bool CheckSumDivisible(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 8 == 0)
                return true;

            return false;
        }
    }
}
