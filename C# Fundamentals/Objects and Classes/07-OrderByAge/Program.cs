using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();
            List<Person> people = new List<Person>();

            while (arr[0] != "End")
            {
                string name = arr[0];
                string id = arr[1];
                int age = int.Parse(arr[2]);

                Person person = new Person(name, id, age);
                people.Add(person);

                if (people.Any(p => p.ID == id))
                {

                    foreach (var personn in people)
                    {
                        if (personn.ID == id)
                        {

                            personn.UpdateInfo(name, age);

                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                arr = Console.ReadLine().Split().ToArray();
            }
            people = people.OrderBy(p => p.Age).ToList();

            foreach (var element in people)
            {
                Console.WriteLine(element);
            }
        }
    }
}
