using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           // var numbers = int.Parse(Console.ReadLine());
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

            //var list = new List<double>();
            //for (int i = 0; i < numbers; i++)
            //{
            //    var input = double.Parse(Console.ReadLine());
            //    list.Add(input);
            //}

            //var box = new Box<double>(list);
            //var elementToCompare = double.Parse(Console.ReadLine());
            //var count = box.CountOfEl(list, elementToCompare);
            //Console.WriteLine(count);

            var personInfo = Console.ReadLine().Split();

            var fullName = $"{personInfo[0]} {personInfo[1]}";

            var city = $"{personInfo[2]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var numberOfLiters = int.Parse(nameAndBeer[1]);

            var numbersInput = Console.ReadLine().Split();
            var intNum = int.Parse(numbersInput[0]);
            var doubleNum = double.Parse(numbersInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName,city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name,numberOfLiters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum,doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);


        }
    }
}
