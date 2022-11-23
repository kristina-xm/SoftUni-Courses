namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> detained = new List<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split(' ');

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string identity = input[2];
                    detained.Add(identity);
                }
                else if (input.Length == 2)
                {
                    string identity = input[1];
                    detained.Add(identity);
                }

                command = Console.ReadLine();
            }

            string validation = Console.ReadLine();

            Console.WriteLine(string.Join("\n", CheckIdentity(detained, validation)));

        }

        static List<string> CheckIdentity(List<string> identities, string validation)
        {
            List<string> notValid = new List<string>();

            foreach (var item in identities)
            {
                var result = item.Substring(item.Length - validation.Length).ToCharArray();

                char[] newValidatoion = validation.ToCharArray();

                int counter = 0;
                for (int i = 0; i < newValidatoion.Length; i++)
                {
                    if (result[i] == newValidatoion[i])
                    {
                        counter++;
                    }
                }

                if (counter == validation.Length)
                {
                    notValid.Add(item.ToString());
                }
                else
                {
                    continue;
                }
            }
            return notValid;
        }
    }
}
