using System;
using System.Text;

namespace WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            StringBuilder sbDest = new StringBuilder();
            sbDest.Append(destinations);

            string[] commands = Console.ReadLine().Split(":");

            while (commands[0] != "Travel")
            {
                string cmdType = commands[0];

                if (cmdType == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string substring = commands[2];

                    if (index >= 0 && index <= sbDest.Length - 1)
                    {
                        sbDest.Insert(index, substring);
                        Console.WriteLine(sbDest.ToString());
                    }
                    else
                    {
                        Console.WriteLine(sbDest.ToString());
                    }
                }
                else if (cmdType == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if ((startIndex >= 0 && startIndex <= sbDest.Length - 1) && (endIndex >= 0 && endIndex <= sbDest.Length - 1))
                    {
                        int length = endIndex - startIndex;
                        sbDest.Remove(startIndex, length + 1);
                        Console.WriteLine(sbDest.ToString());
                    }
                    else
                    {
                        Console.WriteLine(sbDest.ToString());
                    }
                }
                else if (cmdType == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    if (sbDest.ToString().Contains(oldString))
                    {
                        sbDest.Replace(oldString, newString);
                        Console.WriteLine(sbDest.ToString());
                    }
                    else
                    {
                        Console.WriteLine(sbDest.ToString());
                    }
                }

                commands = Console.ReadLine().Split(":");
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {sbDest.ToString()}");
        }
    }
}
