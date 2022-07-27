using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02_MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> inputs = new List<string>();
            List<string> matc = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                inputs.Add(input);
            }

            Regex patternReg = new Regex(@"(\!)(?<command>[A-Z]{1}[a-z]{2,})(\1)\:\[(?<message>[A-Za-z]{8,})\]");

            string pattern = @"(\!)(?<command>[A-Z]{1}[a-z]{2,})(\1)\:\[(?<message>[A-Za-z]{8,})\]";

            for (int i = 0; i < inputs.Count; i++)
            {
                if (Regex.IsMatch(inputs[i], pattern))
                {
                    MatchCollection matches = patternReg.Matches(inputs[i]);

                    foreach (Match match in matches)
                    {
                        string command = match.Groups["command"].Value;
                        string message = match.Groups["message"].Value;

                        char[] chars = message.ToCharArray();
                        List<int> numbers = new List<int>();

                        foreach (var item in chars)
                        {
                            int num = (int)item;
                            numbers.Add(num);
                        }

                        Console.WriteLine($"{command}: {string.Join(" ", numbers)}");
                       
                    }

                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
