using System;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int wagons = int.Parse(Console.ReadLine());
            int[] peopleOnWagon = new int[wagons];

            int totalPeople = 0;

            for (int m = 0; m < wagons; m++)
            {
                peopleOnWagon[m] = int.Parse(Console.ReadLine());

            }
            foreach (int person in peopleOnWagon)
            {

                Console.Write($"{person} ");
                totalPeople += person;
            }
            Console.WriteLine($"\n{totalPeople}");

        }
    }
}
