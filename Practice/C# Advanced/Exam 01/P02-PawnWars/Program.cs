using System;
using System.Collections.Generic;

namespace PawnWar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char[,] matrix = new char[8, 8];
            int startRowW = 0;
            int startColW = 0;

            int startRowB = 0;
            int startColB = 0;

            //var coordinatesAndNames = new Dictionary<Dictionary<int, int>, string>();
            //var coordinates = new Dictionary<int, int>();

            string coordinates = "";

            for (int r = 0; r < 8; r++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();

                for (int c = 0; c < 8; c++)
                {
                    matrix[r, c] = symbols[c];

                    if (symbols[c] == 'w')
                    {
                        startRowW = r;
                        startColW = c;
                    }
                    else if (symbols[c] == 'b')
                    {
                        startRowB = r;
                        startColB = c;
                    }
                }
            }

            bool endNotReached = true;
            while (endNotReached)
            {
                coordinates = CaptureWhite(matrix, startRowW, startColW, startRowB, startColB);

                if (coordinates != " ")
                {
                    Console.WriteLine($"Game over! White capture on {coordinates}.");
                    endNotReached = false;
                    continue;
                }

                matrix = WhitePawnMoves(matrix, startRowW, startColW);
                if (startRowW == 0)
                {
                    coordinates = FindCoordinates(startRowW, startColW);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    endNotReached = false;
                }
                startRowW--;

                coordinates = CaptureBlack(matrix, startRowW, startColW, startRowB, startColB);

                if (coordinates != " ")
                {
                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    endNotReached = false;
                    continue;
                }
                matrix = BlackPawnMoves(matrix, startRowB, startColB);

                if (startRowB == 7)
                {
                    coordinates = FindCoordinates(startRowB, startColB);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    endNotReached = false;
                }
                startRowB++;
            }
        }

        static string CaptureWhite(char[,] matrix, int startRowW, int startColW, int startRowB, int startColB)
        {

            if (startRowW == startRowB + 1 || startRowW == startRowB - 1)
            {
                if (startColW == startColB - 1 || startColW == startColB + 1)
                {
                    return CapturesWhite(matrix, startRowW, startColW);
                }
                else
                {
                    return " ";
                }
            }
            else
            {
                return " ";
            }
        }

        static string CaptureBlack(char[,] matrix, int startRowW, int startColW, int startRowB, int startColB)
        {

            if (startRowW == startRowB + 1 || startRowW == startRowB - 1)
            {
                if (startColW == startColB - 1 || startColW == startColB + 1)
                {
                    return CapturesBlack(matrix, startRowB, startColB);
                }
                else
                {
                    return " ";
                }
            }
            else
            {
                return " ";
            }
        }

        static char[,] WhitePawnMoves(char[,] matrix, int startRowW, int startColW)
        {
            if (WhiteEndNotYet(startRowW))
            {
                matrix[startRowW - 1, startColW] = 'w';
                matrix[startRowW, startColW] = '-';

                return matrix;
            }
            else
            {
                return matrix;
            }
        }

        static bool WhiteEndNotYet(int startRowW)
        {
            if (startRowW <= 0)
            {
                return false;
            }
            return true;
        }

        static char[,] BlackPawnMoves(char[,] matrix, int startRowB, int startColB)
        {
            if (BlackEndNotYet(startRowB))
            {
                matrix[startRowB + 1, startColB] = 'b';
                matrix[startRowB, startColB] = '-';

                return matrix;
            }
            else
            {
                return matrix;
            }
        }

        static bool BlackEndNotYet(int startRowB)
        {
            if (startRowB >= 7)
            {
                return false;
            }
            return true;
        }

        static string FindCoordinates(int startRow, int startCow)
        {
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h" };
            string[] nums = { "8", "7", "6", "5", "4", "3", "2", "1" };

            string num = " ";
            string letter = " ";
            string coordinate = " ";

            for (int i = 0; i < 8; i++)
            {
                if (i == startRow)
                {
                    num = nums[i];

                    for (int j = 0; j < 8; j++)
                    {
                        if (j == startCow)
                        {
                            letter = letters[j];
                            coordinate = $"{letter}{num}";
                            break;
                        }
                    }
                }
            }
            return coordinate;

        }

        static string CapturesWhite(char[,] matrix, int startRow, int startCol)
        {
            string coords = " ";
            if (startCol == 0)
            {
                if (matrix[startRow, startCol] == 'w')
                {
                    if (matrix[startRow - 1, startCol + 1] == 'b')
                    {
                        coords = FindCoordinates(startRow - 1, startCol + 1);
                    }
                }
            }
            else if (startCol == matrix.GetLength(1) - 1)
            {
                if (matrix[startRow - 1, startCol - 1] == 'b')
                {
                    coords = FindCoordinates(startRow - 1, startCol - 1);
                }
            }
            else
            {
                if (matrix[startRow, startCol] == 'w')
                {
                    if (matrix[startRow - 1, startCol + 1] == 'b')
                    {
                        coords = FindCoordinates(startRow - 1, startCol + 1);
                    }
                    else if (matrix[startRow - 1, startCol - 1] == 'b')
                    {
                        coords = FindCoordinates(startRow - 1, startCol - 1);
                    }
                }
            }
            return coords;
        }
        static string CapturesBlack(char[,] matrix, int startRow, int startCol)
        {
            string coords = " ";

            if (startCol == 0)
            {
                if (matrix[startRow + 1, startCol + 1] == 'w')
                {
                    coords = FindCoordinates(startRow + 1, startCol + 1);
                }
            }
            else if (startCol == matrix.GetLength(1) - 1)
            {
                if (matrix[startRow + 1, startCol - 1] == 'w')
                {
                    coords = FindCoordinates(startRow + 1, startCol - 1);
                }
            }
            else
            {
                if (matrix[startRow, startCol] == 'b')
                {
                    if (matrix[startRow + 1, startCol + 1] == 'w')
                    {
                        coords = FindCoordinates(startRow + 1, startCol + 1);
                    }
                    else if (matrix[startRow + 1, startCol - 1] == 'w')
                    {
                        coords = FindCoordinates(startRow + 1, startCol - 1);
                    }
                }
            }

            return coords;
        }
    }
}