using System;
using System.Linq;

namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[] topIntegers = new int[arr.Length];
            int topIntegerIndex = 0;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                int currentNum = arr[i];
                bool isTopInteger = true;

                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    int nextNum = arr[j];
                    if (nextNum >= currentNum)
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    topIntegers[topIntegerIndex] = currentNum;
                    topIntegerIndex++;
                }
            }

            for (int i = 0; i < topIntegerIndex; i++)
            {
                int currentTopInteger = topIntegers[i];
                Console.Write($"{currentTopInteger} ");
            }
        }
    }
}
