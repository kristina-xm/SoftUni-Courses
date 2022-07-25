using System;

namespace Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            long factorielOne = GetFactorielFirstNumber(firstNum);
            long factorielTwo = GetFactorielSecondNumber(secondNum);

            double result = (factorielOne * 1.0 / factorielTwo);
            Console.WriteLine($"{result:F2}");
        }

        static long GetFactorielFirstNumber(int firstNum)
        {
            long factorial1 = 1;

            for (int i = 1; i <= firstNum; i++)
            {
                factorial1 *= i;
            }
            return factorial1;
        }

        static long GetFactorielSecondNumber(int secondNum)
        {
            long factorial2 = 1;

            for (int i = 1; i <= secondNum; i++)
            {
                factorial2 *= i;
            }
            return factorial2;
        }
    }
}
