using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirroredWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex pattern = new Regex(@"(\#|\@)(?<word>[A-Za-z]{3,})(\1){2}(?<secondWord>[A-Za-z]{3,})(\1)");

            MatchCollection matches = pattern.Matches(text);

            List<string> validPairs = new List<string>();

            Dictionary<string, string> mirroredPairs = new Dictionary<string, string>();

            foreach (Match match in matches)
            {
                validPairs.Add(match.Value);
                string word1 = match.Groups["word"].Value;
                string word2 = match.Groups["secondWord"].Value;

                char[] charsFirstWord = word1.ToCharArray();
                Array.Reverse(charsFirstWord);
                string word1Reversed = new string(charsFirstWord);

                if (word1Reversed == word2)
                {
                    mirroredPairs.Add(word1, word2);
                }
                else
                {
                    continue;
                }
            }

            if (validPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");
            }

            if (mirroredPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                int counter = 0;
                foreach (var kvp in mirroredPairs)
                {
                    counter++;
                    if (counter == mirroredPairs.Count)
                    {
                        Console.Write($"{kvp.Key} <=> {kvp.Value}");
                        break;
                    }
                    Console.Write($"{kvp.Key} <=> {kvp.Value}, ");
                }
            }
        }
    }
}
