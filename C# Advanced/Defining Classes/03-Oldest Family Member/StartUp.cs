using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 1; i <= n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split()[0];
                int age = int.Parse(data.Split()[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);

            //Person person = new Person("Peter", 20);
            //Person person1 = new Person("George", 18);
            //Person person2 = new Person("Jose", 43);

            //Family family = new Family();

            //family.AddMember(person);
            //family.AddMember(person1);
            //family.AddMember(person2);
        }
    }
}
