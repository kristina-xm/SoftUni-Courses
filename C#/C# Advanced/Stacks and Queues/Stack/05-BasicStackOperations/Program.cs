using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersCmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //integer N representing the number of elements to push into the stack
            int N = numbersCmd[0];

            //integer S representing the number of elements to pop from the stack
            int S = numbersCmd[1];

            //an integer X, an element that you should look for in the stack.
            int X = numbersCmd[2];

            Stack<int> stack = new Stack<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < N; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
