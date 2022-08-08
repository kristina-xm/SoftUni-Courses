using System;
using System.Linq;

namespace SnakeMoves
{
    internal class Snake_Moves
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string snake = Console.ReadLine();

            char[,] matrix = new char[size[0], size[1]];
            char[] moves = snake.ToCharArray();

            int index = 0;

            for (int r = 0; r < size[0]; r++)
            {

                if (r % 2 == 0)
                {
                    for (int c = 0; c < size[1]; c++)
                    {
                        matrix[r, c] = moves[index];
                        index++;
                        
                        if (index >= moves.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    for (int c = size[1] - 1; c >= 0; c--)
                    {
                        matrix[r, c] = moves[index];
                        index++;
                        
                        if (index >= moves.Length)
                        {
                            index = 0;
                        }
                    }
                }
                
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]}");
                }
                Console.WriteLine();
            }

        }
    }
}
