using System;
using System.Linq;

namespace SquaresMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            int equalMatrix = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] letters = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = letters[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        equalMatrix++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(equalMatrix);
        }
    }
}
