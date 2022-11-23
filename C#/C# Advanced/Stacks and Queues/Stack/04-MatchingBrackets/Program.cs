using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if (c == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string subexpression = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(subexpression);
                }
            }
        }
    }
}
