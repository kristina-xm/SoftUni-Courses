using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            long bestSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            long currentSum = 0;
          

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    currentSum = CalculateSum(row, col, matrix);

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }

            }

            int initialColValue = bestCol;
            int[,] bestMatrix = new int[3, 3];

            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++)
                {
                    bestMatrix[i, j] = matrix[bestRow, bestCol];
                    bestCol++;
                    
                }
                bestRow++;
                bestCol = initialColValue;
            }

            Console.WriteLine($"Sum = {bestSum}");
            PrintBestMatrix(bestMatrix);


        }

        static long CalculateSum(int row, int col, int[,] matrix)
        {
            long currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

            return currSum;
        }

        static void PrintBestMatrix(int[,] bestMatrix)
        {
            for (int r = 0; r < bestMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < bestMatrix.GetLength(1); c++)
                {
                    Console.Write($"{bestMatrix[r, c]} ");

                }
                Console.WriteLine();
            }

        }
    }
}
