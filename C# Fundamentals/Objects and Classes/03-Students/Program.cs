using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split();

                string firstName = information[0];
                string lastName = information[1];
                double grade = double.Parse(information[2]);

                Student newStudent = new Student(firstName, lastName, grade);

                students.Add(newStudent);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
