using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInput = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals = new SortedSet<string>();

            for (int i = 0; i < countOfInput; i++)
            {
                string[] chemicalComprounds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < chemicalComprounds.Length; j++)
                {
                    chemicals.Add(chemicalComprounds[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
