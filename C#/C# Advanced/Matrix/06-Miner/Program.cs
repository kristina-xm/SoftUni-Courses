using System;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ');

            string[,] matrix = new string[fieldSize, fieldSize];
            int startRow = 0;
            int startCol = 0;

            int coalNumber = 0;

            for (int r = 0; r < fieldSize; r++)
            {
                string[] symbols = Console.ReadLine().Split(' ');

                for (int i = 0; i < fieldSize; i++)
                {
                    matrix[r, i] = symbols[i];
                    if (symbols[i] == "s")
                    {
                        startRow = r;
                        startCol = i;
                    }
                    else if (symbols[i] == "c")
                    {
                        coalNumber++;
                    }
                }
            }

            string currentSymbol = "";

            int currRowIndex = startRow;
            int currColIndex = startCol;
            int collectedCoal = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "left")
                {
                    currColIndex = currColIndex - 1;
                    if (CheckInvalidColIndex(currColIndex, fieldSize))
                    {
                        currColIndex++;
                        continue;
                    }

                    //currColIndex = startCol;
                    currentSymbol = matrix[currRowIndex, currColIndex];


                    if (currentSymbol == "c")
                    {
                        collectedCoal++;
                        matrix[currRowIndex, currColIndex] = "*";
                    }
                    else if (currentSymbol == "e")
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        return;
                    }

                }
                else if (commands[i] == "right")
                {
                    currColIndex = currColIndex + 1;
                    if (CheckInvalidColIndex(currColIndex, fieldSize))
                    {
                        currColIndex--;
                        continue;
                    }

                    //currColIndex = startCol;
                    currentSymbol = matrix[currRowIndex, currColIndex];

                    if (currentSymbol == "c")
                    {
                        collectedCoal++;
                        matrix[currRowIndex, currColIndex] = "*";
                    }
                    else if (currentSymbol == "e")
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        return;
                    }
                }
                else if (commands[i] == "up")
                {
                    currRowIndex = currRowIndex - 1;
                    if (CheckInvalidRowIndex(currRowIndex, fieldSize))
                    {
                        currRowIndex++;
                        continue;
                    }

                    //currRowIndex = startCol;
                    currentSymbol = matrix[currRowIndex, currColIndex];

                    if (currentSymbol == "c")
                    {
                        collectedCoal++;
                        matrix[currRowIndex, currColIndex] = "*";
                    }
                    else if (currentSymbol == "e")
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        return;
                    }

                }
                else if (commands[i] == "down")
                {
                    currRowIndex = currRowIndex + 1;
                    if (CheckInvalidRowIndex(currRowIndex, fieldSize))
                    {
                        currRowIndex--;
                        continue;
                    }

                    currentSymbol = matrix[currRowIndex, currColIndex];


                    if (currentSymbol == "c")
                    {
                        collectedCoal++;
                        matrix[currRowIndex, currColIndex] = "*";
                    }
                    else if (currentSymbol == "e")
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        return;
                    }
                }
            }

            if (collectedCoal == coalNumber)
            {

                Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
            }
            else
            {
                Console.WriteLine($"{coalNumber - collectedCoal} coals left. ({currRowIndex}, {currColIndex})");
            }
        }

        static bool CheckInvalidColIndex(int currColIndex, int fieldSize)
        {
            if (currColIndex < 0 || currColIndex >= fieldSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CheckInvalidRowIndex(int currRowIndex, int fieldSize)
        {
            if (currRowIndex < 0 || currRowIndex >= fieldSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
}
