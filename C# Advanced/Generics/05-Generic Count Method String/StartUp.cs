using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = int.Parse(Console.ReadLine());
            //var list = new List<int>();

            //for (int i = 0; i < numbers; i++)
            //{
            //    var input = int.Parse(Console.ReadLine());
            //   list.Add(input);
            //}

            //var box = new Box<int>(list);
            //var index = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //box.Swap(list, index[0], index[1]);
            //Console.WriteLine(box);

            var list = new List<string>();
            for (int i = 0; i < numbers; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);

            }
            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();
            var count = box.CountOfEl(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
