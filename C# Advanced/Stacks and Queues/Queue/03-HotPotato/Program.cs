using System;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int countOfSessions = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>(names);

            while (circle.Count > 1)
            {
                for (int i = 1; i <= countOfSessions - 1; i++)
                {
                    string player = circle.Dequeue();
                    circle.Enqueue(player);

                }
                string removedPlayer = circle.Dequeue();
                Console.WriteLine($"Removed {removedPlayer}");
            }

            Console.WriteLine($"Last is {string.Join("", circle)}");

            //Alva James William
            //2
            //William Alva
        }
    }
}
