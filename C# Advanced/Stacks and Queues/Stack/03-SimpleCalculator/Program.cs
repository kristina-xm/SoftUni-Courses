using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> tokens = Console.ReadLine().Split().ToList();

            tokens.Reverse();

            Stack<string> stack = new Stack<string>();

            int result = 0;

            foreach (var token in tokens)
            {
                stack.Push(token);
            }
            
            int num1 = int.Parse(stack.Pop());
            result += num1;

            for (int i = 0; i < tokens.Count; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                string operation = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    result += num2; 
                }
                else if (operation == "-")
                {
                    result -= num2;
                }
            }
            Console.WriteLine(result);
        }
    }
}
