using System;
using System.Collections.Generic;
using System.Linq;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command = Console.ReadLine();
            List<char> characters = encryptedMessage.ToList();


            while (command != "Decode")
            {
                List<string> splittedCmd = command.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (splittedCmd[0] == "Move")
                {
                    int numberOfLetters = int.Parse(splittedCmd[1]);
                    for (int i = 0; i < numberOfLetters; i++)
                    {

                        characters.Add(characters[i]);
                        characters[i] = '*';

                    }
                    characters.RemoveAll(c => c == '*');

                }
                else if (splittedCmd[0] == "Insert")
                {
                    int index = int.Parse(splittedCmd[1]);
                    string value = splittedCmd[2];

                    if (value.Length > 1)
                    {

                        for (int i = value.Length - 1; i >= 0; i--)
                        {
                            characters.Insert(index, value[i]);
                        }
                    }
                    else
                    {
                        characters.Insert(index, char.Parse(value));
                    }


                }
                else if (splittedCmd[0] == "ChangeAll")
                {
                    string substring = splittedCmd[1];
                    string replacement = splittedCmd[2];

                    for (int i = 0; i < characters.Count; i++)
                    {
                        if (characters[i] == char.Parse(substring))
                        {
                            characters[i] = char.Parse(replacement);
                        }
                        continue;
                    }

                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {string.Join("", characters)}");
        }
    }
}
