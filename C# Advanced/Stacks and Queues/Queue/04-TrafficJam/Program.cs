using System;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string cmd = Console.ReadLine();

            int numberPassed = 0;   

            Queue<string> queue = new Queue<string>();

            while (cmd != "end")
            {
                if (cmd != "green")
                {
                    queue.Enqueue(cmd);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        string car = queue.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        numberPassed++;
                    }
                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{numberPassed} cars passed the crossroads.");
        }
    }
}
