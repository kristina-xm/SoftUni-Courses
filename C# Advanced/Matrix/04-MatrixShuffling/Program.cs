using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] letters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = letters[col];
                }
            }

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (cmd[0] != "END")
            {
                if (cmd[0] == "swap" && cmd.Length == 5)
                {
                    int currRow = int.Parse(cmd[1]);
                    int currCol = int.Parse(cmd[2]);
                    int newRow = int.Parse(cmd[3]);
                    int newCol = int.Parse(cmd[4]);

                    if (ValidateIndex(currRow, currCol, newRow, newCol, rows, cols))
                    {
                        string ch = matrix[currRow, currCol];
                        matrix[currRow, currCol] = matrix[newRow, newCol];
                        matrix[newRow, newCol] = ch;

                        PrintMatrix(matrix, rows, cols);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }



        static bool ValidateIndex(int currRow, int currCol, int newRow, int newCol, int rows, int cols)
        {
            if ((currRow >= 0 && currRow <= rows - 1) && (currCol >= 0 && currCol <= cols - 1))
            {
                if ((newRow >= 0 && newRow <= rows - 1) && (newCol >= 0 && newCol <= cols - 1))
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static void PrintMatrix(string[,] matrix, int rows, int cols)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
