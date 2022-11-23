using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var item in numbers)
            {
                queue.Enqueue(item);
            }

           
            List<int> list = new List<int>();

            for (int  i = 0;  i < numbers.Length;  i++)
            {
                int num = queue.Dequeue();
                if (num % 2 == 0)
                {
                    
                    list.Add(num);
                }
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
