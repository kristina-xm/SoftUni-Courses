using System;
using System.Collections.Generic;

namespace P03_MessagesManager
{
    internal class Program
    {
        public class User
        {
            public User(double sent, double received)
            {
                this.Sent = sent;
                this.Received = received;
            }
            public double Sent { get; set; }
            public double Received { get; set; }

        }
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split("=",StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, User> users = new Dictionary<string, User>();

            while (command[0] != "Statistics")
            {
                if (command[0] == "Add")
                {
                    string username = command[1];
                    double sent = double.Parse(command[2]);
                    double received = double.Parse(command[3]);

                    if (!users.ContainsKey(username))
                    {
                        User user = new User(sent, received);
                        users.Add(username, user);
                    }
                    else
                    {
                        command = Console.ReadLine().Split("=", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                else if (command[0] == "Message")
                {
                    string sender = command[1];
                    string receiver = command[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender].Sent += 1;
                        users[receiver].Received += 1;


                        if (users[sender].Sent + users[sender].Received >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            users.Remove(sender);
                        }
                        if (users[receiver].Sent + users[receiver].Received >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            users.Remove(receiver);
                        }
                    }
                }
                else if (command[0] == "Empty")
                {
                    string username = command[1];

                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }

                    if (username == "All")
                    {
                        users.Clear();
                    }
                }

                command = Console.ReadLine().Split("=", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var kvp in users)
            { 
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Sent + kvp.Value.Received}");
            }
        }
    }
}
