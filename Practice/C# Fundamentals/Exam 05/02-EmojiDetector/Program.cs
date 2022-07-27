using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string onlyNumbers = new String(input.Where(Char.IsDigit).ToArray());

            int[] numericValues = onlyNumbers.ToArray().Select(c => (int)char.GetNumericValue(c)).ToArray();

            long coolThershold = 1;

            for (int i = 0; i < numericValues.Length; i++)
            {
                coolThershold *= numericValues[i];
            }
            Console.WriteLine($"Cool threshold: {coolThershold}");

            Regex pattern = new Regex(@"([\:]{2}|[\*]{2})(?<emoji>[A-Z]{1}[a-z]{2,})(\1)");
            MatchCollection matches = pattern.Matches(input);
            List<string> emojis = new List<string>();

            foreach (Match match in matches)
            {
                string emoji = match.Groups["emoji"].Value;
                emojis.Add(emoji);
            }
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            Dictionary<string, int> emojiCoolness = new Dictionary<string, int>();

            foreach (string emoj in emojis)
            {
                int sumOfASCII = 0;

                foreach (char charact in emoj)
                {
                    sumOfASCII += (int)charact;
                }
                emojiCoolness.Add(emoj, sumOfASCII);
            }

            List<string> coolEmojis = new List<string>();
            foreach (var kvp in emojiCoolness)
            {
                if (kvp.Value >= coolThershold)
                {
                    coolEmojis.Add(kvp.Key);
                }
            }

            List<string> forPrinting = new List<string>();
            MatchCollection matches2 = pattern.Matches(input);
            foreach (Match match in matches2)
            {
                string comparison = match.Groups["emoji"].Value;
                foreach (var item in coolEmojis)
                {
                    if (comparison == item)
                    {
                        string emoji = match.Groups[0].Value;
                        forPrinting.Add(emoji);
                    }
                }
            }

            Console.WriteLine(string.Join("\n", forPrinting));
        }
    }
}
