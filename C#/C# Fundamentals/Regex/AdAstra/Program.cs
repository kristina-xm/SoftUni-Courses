using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(\#|\|)(?<item>[A-Za-z\s]+)(\1)(?<date>\d{2}\/\d{2}\/\d{2})(\1)(?<calories>\d+|(\d+)?\.(\d+)?)(\1)");

            MatchCollection matches = regex.Matches(input);

            int allCalories = 0;

            foreach (Match match in matches)
            {
                string item = match.Groups["item"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                allCalories+= calories;
            }
            // for a single day I need 2000
            int days = 0;
            while (allCalories >= 2000)
            {
                allCalories -= 2000;
                days++;
            }
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in matches)
            {
                string item = match.Groups["item"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {item}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
