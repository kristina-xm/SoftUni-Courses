using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsStrings = Console.ReadLine().Split("|").Reverse().ToList();
            List<int> numList = new List<int>();

            foreach (string number in numbersAsStrings)
            {
                numList.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }
            Console.WriteLine(string.Join(" ", numList));
        }
    }
}
