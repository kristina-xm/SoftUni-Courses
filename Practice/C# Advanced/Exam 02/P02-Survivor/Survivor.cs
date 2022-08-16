using System;
using System.Linq;

namespace Survivor
{
    internal class Survivor
    {
        static void Main(string[] args)
        {
            int beachRows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[beachRows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                matrix[row] = new string[tokens.Length];

                for (int j = 0; j < tokens.Length; j++)
                {
                    matrix[row][j] = tokens[j];
                }
            }

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int counOfCollected = 0;
            int countOfOpponentsTokens = 0;

            while (cmd[0] != "Gong")
            {
                if (cmd[0] == "Find")
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);

                    if (ValidateIndex(matrix, row, col))
                    {
                        counOfCollected += CountTokens(matrix, row, col, counOfCollected);
                        matrix = CollectTokens(matrix, row, col);

                    }
                }
                else if (cmd[0] == "Opponent")
                {
                    int oppRow = int.Parse(cmd[1]);
                    int oppCol = int.Parse(cmd[2]);
                    string direction = cmd[3];

                    if (ValidateIndex(matrix, oppRow, oppCol))
                    {
                        countOfOpponentsTokens += CountTokens(matrix, oppRow, oppCol, countOfOpponentsTokens);
                        matrix = CollectTokens(matrix, oppRow, oppCol);
                        countOfOpponentsTokens += OpponentsTokens(direction, matrix, oppRow, oppCol, countOfOpponentsTokens);

                    }
                }

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }

            Console.WriteLine($"Collected tokens: {counOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }

        static bool ValidateIndex(string[][] matrix, int row, int col)
        {

            if (row > matrix.GetLength(0) || row < 0)
            {
                return false;
            }
            else if (col > matrix[row].Length || col < 0)
            {
                return false;
            }
            return true;
        }

        static bool ValidateOpponentMove(string direction, string[][] matrix, int row, int col)
        {
            if (direction == "up")
            {
                if (ValidateIndex(matrix, row - 3, col))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == "down")
            {
                if (ValidateIndex(matrix, row + 3, col))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == "left")
            {
                if (ValidateIndex(matrix, row, col - 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == "right")
            {
                if (ValidateIndex(matrix, row, col + 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        static string[][] CollectTokens(string[][] matrix, int currRow, int currCol)
        {
            if (matrix[currRow][currCol] == "T")
            {
                matrix[currRow][currCol] = "-";
                return matrix;
            }
            return matrix;
        }

        static int CountTokens(string[][] matrix, int currRow, int currCol, int count)
        {
            count = 0;
            if (matrix[currRow][currCol] == "T")
            {

                count++;
                return count;

            }
            return count;
        }

        static int OpponentsTokens(string direction, string[][] matrix, int row, int col, int count)
        {
            count = 0;
            if (ValidateOpponentMove(direction, matrix, row, col))
            {
                if (direction == "up")
                {
                    for (int i = row; i >= row - 3; i--)
                    {
                        if (matrix[i][col] == "T")
                        {
                            count++;
                            matrix[i][col] = "-";
                        }
                    }
                }
                else if (direction == "down")
                {
                    for (int i = row; i <= row + 3; i++)
                    {
                        if (matrix[i][col] == "T")
                        {
                            count++;
                            matrix[i][col] = "-";
                        }
                    }
                }
                else if (direction == "left")
                {
                    for (int i = col; i >= col - 3; i--)
                    {
                        if (matrix[row][i] == "T")
                        {
                            count++;
                            matrix[row][i] = "-";
                        }
                    }
                }
                else if (direction == "right")
                {
                    for (int i = col; i <= col + 3; i++)
                    {
                        if (matrix[row][i] == "T")
                        {
                            count++;
                            matrix[row][i] = "-";
                        }
                    }
                }
            }
            return count;
        }
    }
}
