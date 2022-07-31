using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(sequence);

            Console.WriteLine(queue.Max());

            for (int i = 0; i < sequence.Length; i++)
            {
                if (queue.Peek() <= quantity)
                {
                    quantity -= queue.Peek();
                    queue.Dequeue();
                    if (quantity == 0)
                    {
                        break;
                    }
                    
                    if (queue.Count == 0)
                    {
                        break;
                    }
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
