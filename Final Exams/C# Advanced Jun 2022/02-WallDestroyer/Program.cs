using System;
using System.Collections.Generic;
using System.Linq;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int rowMaster = 0;
            int colMaster = 0;

            int countOfRode = 0;
            int countOfHoles = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = input[col];
                    if (matrix[row, col] == 'V')
                    {
                        rowMaster = row;
                        colMaster = col;
                    }
                }
            }

            string command = Console.ReadLine();

            bool HitByElectricity = false;

            while (command != "End")
            {
                if (command == "up")
                {
                    rowMaster--;
                   
                    if (RowValidator(rowMaster, matrix))
                    {
                        var area = matrix[rowMaster, colMaster];

                        if (area == '-')
                        {
                            matrix[rowMaster + 1, colMaster] = '*';
                            countOfHoles++;
                        }
                        else if (area == 'R')
                        {
                            countOfRode++;
                            rowMaster++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (area == 'C')
                        {
                            matrix[rowMaster, colMaster] = 'E';
                            matrix[rowMaster + 1, colMaster] = '*';
                            countOfHoles++;
                            HitByElectricity = true;
                            break;
                        }
                        else if (area == '*')
                        {
                            matrix[rowMaster + 1, colMaster] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowMaster}, {colMaster}]!");
                        }
                    }
                    else
                    {
                        rowMaster = RowNotMoved(rowMaster, matrix);
                        command = Console.ReadLine();
                        continue;
                    }                    
                    
                }
                else if (command == "down")
                {
                    rowMaster++;
                    if (RowValidator(rowMaster, matrix))
                    {
                        var area = matrix[rowMaster, colMaster];

                        if (area == '-')
                        {
                            matrix[rowMaster - 1, colMaster] = '*';
                            countOfHoles++;
                        }
                        else if (area == 'R')
                        {
                            countOfRode++;
                            rowMaster--;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (area == 'C')
                        {
                            matrix[rowMaster, colMaster] = 'E';
                            matrix[rowMaster - 1, colMaster] = '*';
                            countOfHoles++;
                            HitByElectricity = true;
                            break;
                        }
                        else if (area == '*')
                        {
                            matrix[rowMaster - 1, colMaster] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowMaster}, {colMaster}]!");
                        }
                    }
                    else
                    {
                        rowMaster = RowNotMoved(rowMaster, matrix);
                        command = Console.ReadLine();
                        continue;
                    }
                    
                }
                else if (command == "left")
                {
                    colMaster--;

                    if (ColValidator(colMaster, matrix))
                    {
                        var area = matrix[rowMaster, colMaster];

                        if (area == '-')
                        {
                            matrix[rowMaster, colMaster + 1] = '*';
                            countOfHoles++;
                        }
                        
                        else if (area == 'R')
                        {
                            countOfRode++;
                            colMaster++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (area == 'C')
                        {
                            matrix[rowMaster, colMaster] = 'E';
                            matrix[rowMaster, colMaster + 1] = '*';
                            countOfHoles++;
                            HitByElectricity = true;
                            break;

                        }
                        else if (area == '*')
                        {
                            matrix[rowMaster, colMaster + 1] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowMaster}, {colMaster}]!");
                        }
                    }
                    else
                    {
                        colMaster = ColNotMoved(colMaster, matrix);
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else if (command == "right")
                {
                    colMaster++;

                    if (ColValidator(colMaster, matrix))
                    {
                        var area = matrix[rowMaster, colMaster];

                        if (area == '-')
                        {
                            matrix[rowMaster, colMaster - 1] = '*';
                           
                            countOfHoles++;
                        }
                        else if (area == 'R')
                        {
                            countOfRode++;
                            colMaster--;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (area == 'C')
                        {
                            matrix[rowMaster, colMaster] = 'E';
                            matrix[rowMaster, colMaster - 1] = '*';
                            countOfHoles++;
                            HitByElectricity = true;
                            break;
                        }
                        else if (area == '*')
                        {
                            matrix[rowMaster, colMaster - 1] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowMaster}, {colMaster}]!");
                        }
                    }
                    else
                    {
                        colMaster = ColNotMoved(colMaster, matrix);
                        command = Console.ReadLine();
                        continue;
                    }
                    
                }
                command = Console.ReadLine();
            }

            if (HitByElectricity)
            {
                
                countOfHoles++;
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        Console.Write($"{matrix[row, col] }");
                    }
                    Console.WriteLine();
                }
                return;
            }
            else
            {
                countOfHoles++;
                matrix[rowMaster, colMaster] = 'V';
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRode} rod(s).");
            }

            
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row,col] }");
                }
                Console.WriteLine();
            }

        }

        static bool RowValidator(int rowVanko, char[,] matrix)
        {
            if (rowVanko < 0 )
            {
                rowVanko = 0;
                return false;
            }
            else if(rowVanko > matrix.GetLength(0) - 1)
            {
                rowVanko = matrix.GetLength(0) - 1;
                return false;
            }
            return true;
        }

        static int RowNotMoved(int rowVanko, char[,] matrix)
        {
            if (rowVanko < 0)
            {
                rowVanko = 0;
                return rowVanko;
            }
            else if (rowVanko > matrix.GetLength(0) - 1)
            {
                rowVanko = matrix.GetLength(0) - 1;
                return rowVanko;
            }
            return 0;
           
        }
        static int ColNotMoved(int colVanko, char[,] matrix)
        {
            if (colVanko < 0)
            {
                colVanko = 0;
                return colVanko;
            }
            else if (colVanko > matrix.GetLength(1) - 1)
            {
                colVanko = matrix.GetLength(1) - 1;
                return colVanko;
            }
            return 0;

        }

        static bool ColValidator(int colVanko, char[,] matrix)
        {
            if (colVanko < 0 )
            {
                return false;
            }
            else if (colVanko > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }
    }
}
