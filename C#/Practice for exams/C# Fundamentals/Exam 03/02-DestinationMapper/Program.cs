using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();

            Regex pattern = new Regex(@"(\=|\/)(?<destination>[A-Z]{1}[a-zA-Z]{2,})(\1)");

            MatchCollection matches = pattern.Matches(places);

            List<string> validDestinations = new List<string>();

            foreach (Match match in matches)
            {
                string destination = match.Groups["destination"].Value;
                validDestinations.Add(destination);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", validDestinations)}");
            int travelPoints = 0;

            foreach (string destination in validDestinations)
            {
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
