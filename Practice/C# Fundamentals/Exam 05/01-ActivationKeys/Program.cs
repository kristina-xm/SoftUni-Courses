using System;
using System.Text;

namespace ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string[] action = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (action[0] != "Generate")
            {
                if (action[0] == "Contains")
                {
                    string substring = action[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action[0] == "Flip")
                {
                    string typeOfCase = action[1];
                    int startIndex = int.Parse(action[2]);
                    int endIndex = int.Parse(action[3]);

                    int length = endIndex - startIndex;

                    string substiring = activationKey.Substring(startIndex, length);
                    if (typeOfCase == "Upper")
                    {
                        StringBuilder sb = new StringBuilder(activationKey);
                        sb.Replace(substiring, substiring.ToUpper());
                        activationKey = sb.ToString();
                        Console.WriteLine(activationKey);

                    }
                    else if (typeOfCase == "Lower")
                    {
                        StringBuilder sb = new StringBuilder(activationKey);
                        sb.Replace(substiring, substiring.ToLower());
                        activationKey = sb.ToString();
                        Console.WriteLine(activationKey);
                    }
                }
                else if (action[0] == "Slice")
                {
                    int startIndex = int.Parse(action[1]);
                    int endIndex = int.Parse(action[2]);

                    int length = endIndex - startIndex;
                    string substringToClear = activationKey.Substring(startIndex, length);

                    StringBuilder sb = new StringBuilder(activationKey);
                    sb.Replace(substringToClear, "");
                    activationKey = sb.ToString();
                    Console.WriteLine(activationKey);
                }
                action = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
