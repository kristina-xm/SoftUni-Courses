using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size,size];

            for (int r = 0; r < size; r++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = nums[c];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;  

            for (int r = 0; r < size; r++)
            {
                primaryDiagonal += matrix[r, r];
            }

            for (int r = 0; r < size; r++)
            {
                for (int c = size - 1; c >= 0; c--)
                {
                    secondaryDiagonal += matrix[r, c];
                    r++;
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
