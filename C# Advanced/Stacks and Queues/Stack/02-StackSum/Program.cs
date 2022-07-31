using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (var num in numbers)
            {
                stack.Push(num);
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] cmd = command.Split();

                if (cmd[0] == "add")
                {
                    int num1 = int.Parse(cmd[1]);
                    int num2 = int.Parse(cmd[2]);
                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (cmd[0] == "remove")
                {
                    int count = int.Parse(cmd[1]);

                    if (stack.Count < count)
                    {
                        command = Console.ReadLine().ToLower();
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
