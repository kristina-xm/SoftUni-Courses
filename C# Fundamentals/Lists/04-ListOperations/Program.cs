using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split().ToArray();
            string typeOfCommand = command[0];

            while (command[0] != "End")
            {
                int number = 0;

                if (typeOfCommand == "Add")
                {
                    number = int.Parse(command[1]);
                    numbers.Add(number);
                }
                else if (typeOfCommand == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine().Split().ToArray();
                        typeOfCommand = command[0];
                        continue;
                    }
                    numbers.RemoveAt(index);

                }
                else if (typeOfCommand == "Insert")
                {
                    number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine().Split().ToArray();
                        typeOfCommand = command[0];
                        continue;
                    }


                    numbers.Insert(index, number);
                }
                else if (typeOfCommand == "Shift")
                {
                    string description = command[1];
                    int count = int.Parse(command[2]);

                    if (description == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int removedNumber = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(removedNumber);
                        }
                    }
                    else if (description == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int removedNumber = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, removedNumber);
                        }
                    }
                }
                command = Console.ReadLine().Split().ToArray();
                typeOfCommand = command[0];
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
