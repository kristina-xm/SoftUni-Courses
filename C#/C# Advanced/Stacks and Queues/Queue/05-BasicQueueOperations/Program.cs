using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersCmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int N = numbersCmd[0];

            int S = numbersCmd[1];
            
            int X = numbersCmd[2];

            Queue<int> queue = new Queue<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < N; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                queue.Dequeue();
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (queue.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
