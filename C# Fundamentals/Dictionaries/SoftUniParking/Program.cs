using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string username = string.Empty;
            string liscencePlateNumber = string.Empty;

            Dictionary<string, string> parkingState = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                if (cmdArgs[0] == "register")
                {
                    username = cmdArgs[1];
                    liscencePlateNumber = cmdArgs[2];

                    if (!parkingState.ContainsKey(username))
                    {
                        parkingState.Add(username, liscencePlateNumber);
                        Console.WriteLine($"{username} registered {liscencePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {liscencePlateNumber}");
                    }
                }
                else if (cmdArgs[0] == "unregister")
                {
                    username = cmdArgs[1];

                    if (!parkingState.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        parkingState.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
                if (i == n -1)
                {
                    break;
                }
                cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                
            }

            foreach (var item in parkingState)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
