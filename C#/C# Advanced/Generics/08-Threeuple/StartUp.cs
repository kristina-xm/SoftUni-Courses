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

            var address = $"{personInfo[2]}";
            var city = $"{personInfo[3]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var numberOfLiters = int.Parse(nameAndBeer[1]);

            var isDrunk = nameAndBeer[2] == "drunk" ? true : false;

            var nameAndBank = Console.ReadLine().Split();

            var perosonName = nameAndBank[0];
            var accountBalace = double.Parse(nameAndBank[1]);
            var bankeName = nameAndBank[2];
             
          

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName,address, city);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool> (name,numberOfLiters, isDrunk);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(perosonName, accountBalace, bankeName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);


        }
    }
}
