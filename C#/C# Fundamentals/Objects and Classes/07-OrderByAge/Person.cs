using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByAge
{
    public class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public void UpdateInfo(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
