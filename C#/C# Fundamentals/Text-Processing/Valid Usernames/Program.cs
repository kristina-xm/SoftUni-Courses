using System;
using System.Collections.Generic;

namespace ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usernames = Console.ReadLine();

            string[] splittedUsernames = usernames.Split(", ",StringSplitOptions.RemoveEmptyEntries);

            List<string> validUserNames = new List<string>();
            

            foreach (string s in splittedUsernames)
            {
                if (s.Length <= 16 && s.Length >= 3)
                {
                    validUserNames.Add(s);
                }
            }

            for (int i = 0; i < validUserNames.Count; i++)
            {
                char[] currUName = validUserNames[i].ToCharArray();

                foreach (char item in currUName)
                {
                    if (char.IsLetter(item))
                    {
                        continue;
                    }
                    else if (char.IsDigit(item))
                    {
                        continue;
                    }
                    else if (!char.IsLetterOrDigit(item))
                    {
                      

                        if ((int)item == 45)
                        {
                            continue;
                        }
                        else if ((int)item == 95)
                        {
                            continue;
                        }
                        else
                        {
                            validUserNames.Remove(validUserNames[i]);
                            if (validUserNames.Count == 1)
                            {
                                Console.WriteLine(string.Join("", validUserNames));
                                return;
                            }
                            else if (validUserNames.Count == 0)
                            {
                                return;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < validUserNames.Count; i++)
            {
                char[] arr = validUserNames[i].ToCharArray();
                int counter = 0;
                foreach (var item in arr)
                {
                    if (!char.IsLetterOrDigit(item))
                    {
                        counter++;
                    }
                }
                if (counter == validUserNames[i].Length)
                {
                    validUserNames.Remove(validUserNames[i]);
                    continue;
                }
                Console.WriteLine(validUserNames[i]);
                
            }
          
        }
        
    }
}
