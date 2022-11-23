using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();

            Queue<string> queue = new Queue<string>();

            while (cmd != "End")
            {
                if (cmd != "Paid")
                {
                    queue.Enqueue(cmd);
                }
                else
                {
                    Console.WriteLine(string.Join("\n", queue));
                    queue.Clear();
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
