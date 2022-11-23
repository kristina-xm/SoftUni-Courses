using System;
using System.Collections.Generic;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numsDict = new Dictionary<int, int>();
            int count = 1;

            for (int i = 0; i < n; i++)
            {

                int num = int.Parse(Console.ReadLine());
                
                if (numsDict.ContainsKey(num))
                {
                    numsDict[num]++;
                }
                else
                {
                    numsDict.Add(num, count);
                }
            }

            foreach (var item in numsDict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine($"{item.Key}");
                }
            }
        }
    }
}
