using System;
using System.Text;

namespace SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder sbMesssage = new StringBuilder();
            sbMesssage.Append(message);

            string[] command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Reveal")
            {

                if (command[0] == "InsertSpace")
                {
                    int index = int.Parse(command[1]);
                    sbMesssage.Insert(index, " ");
                    Console.WriteLine(sbMesssage.ToString());
                }
                else if (command[0] == "Reverse")
                {
                    string substring = command[1];
                    int index = sbMesssage.ToString().IndexOf(substring);

                    if (sbMesssage.ToString().Contains(substring))
                    {
                        sbMesssage.Remove(index, substring.Length);
                        char[] strArr = substring.ToCharArray();
                        Array.Reverse(strArr);
                        string reversed = new string(strArr);

                        sbMesssage.Append(reversed);
                        Console.WriteLine(sbMesssage.ToString());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "ChangeAll")
                {
                    string substring = command[1];
                    string replacement = command[2];

                    sbMesssage.Replace(substring, replacement);
                    Console.WriteLine(sbMesssage.ToString());
                }

                command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {sbMesssage.ToString()}");
        }
    }
}
