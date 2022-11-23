using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split()[0];
                int age = int.Parse(data.Split()[1]);

                Person person = new Person(name, age);
                if (person.Age > 30)
                {
                    people.Add(person);
                   
                }
            }

            List<Person> sortedList = people.OrderBy(p => p.Name).ToList();

            foreach (var person in sortedList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
