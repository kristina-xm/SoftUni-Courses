using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string company = input[0];
            string employeeID = input[1];

            Dictionary < string, List<string>> listOfEmployees = new Dictionary<string, List <string>>();

            List<string> employees = new List<string>();    

            while (input[0] != "End")
            {
                company = input[0];
                employeeID = input[1];


                if (!listOfEmployees.ContainsKey(company))
                {
                    listOfEmployees[company] = new List<string>();
                }

                if (listOfEmployees[company].Contains(employeeID))
                {

                    input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }

                listOfEmployees[company].Add(employeeID);

                input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            PrintEmployessInfo(listOfEmployees);
        }

        static void PrintEmployessInfo(Dictionary<string, List<string>> listOfEmployees)
        {
            foreach (var item in listOfEmployees)
            {
                string company = item.Key;
                List<string> employees = item.Value;

                Console.WriteLine(company);
                foreach (var id in employees)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
