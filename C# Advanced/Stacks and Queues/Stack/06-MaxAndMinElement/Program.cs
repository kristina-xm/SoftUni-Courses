using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxAndMinElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int nQueries = int.Parse(Console.ReadLine());

            int[] cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < nQueries; i++)
            {
                if (cmds[0] == 1)
                {
                    int x = cmds[1];
                    stack.Push(x);
                }
                else if (cmds[0] == 2)
                {
                    if (stack.Count == 0)
                    {
                        cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();
                        continue;
                    }
                    stack.Pop();
                }
                else if (cmds[0] == 3)
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else
                    {
                        cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();
                        continue;
                    }
                }
                else if (cmds[0] == 4)
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    else
                    {
                        cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();
                        continue;
                    }
                }

                if (i < nQueries - 1)
                {
                    cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();
                }
                else
                {
                    break;
                }
                
            }  

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
