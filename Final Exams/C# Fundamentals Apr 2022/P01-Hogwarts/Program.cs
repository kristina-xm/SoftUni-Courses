using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sbSpell = new StringBuilder();
            

            while (command[0] != "Abracadabra")
            {
                if (command[0] == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                    
                }
                else if (command[0] == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                }
                else if (command[0] == "Illusion")
                {
                  
                    int index = int.Parse(command[1]);
                    char letter = char.Parse(command[2]);
                    char letterToReplace = ' ';

                    List<char> charsSpell = spell.ToList();
                    int counter = -1;
                    
                    if (index >= 0 && index <= spell.Length - 1)
                    {
                        //sbSpell.Append(spell);
                        foreach (var item in charsSpell)
                        {
                            counter++;
                            if (counter == index)
                            {
                                letterToReplace = item;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        charsSpell.RemoveAt(counter);
                        charsSpell.Insert(index, letter);

                        spell = string.Join("", charsSpell);
                        
                        //sbSpell.Replace(letterToReplace, letter);
                        //spell = sbSpell.ToString();
                        Console.WriteLine("Done!");
                        sbSpell.Clear();
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                        
                    }
                }
                else if (command[0] == "Divination")
                {
                    string firstSubstring = command[1];
                    string secondSubstring = command[2];

                    if (spell.Contains(firstSubstring))
                    {
                        sbSpell.Append(spell);
                        sbSpell.Replace(firstSubstring, secondSubstring);
                        Console.WriteLine(sbSpell.ToString());
                        spell = sbSpell.ToString();
                        sbSpell.Clear();
                    }
                    else
                    {
                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                }
                else if (command[0] == "Alteration")
                {
                    
                    string substring = command[1];
                    
                    //int indexOfSubstring = spell.IndexOf(substring);

                    if (spell.Contains(substring))
                    {
                        sbSpell.Append(spell);
                        sbSpell.Replace(substring, "");
                        spell = sbSpell.ToString();
                        Console.WriteLine(spell);
                        sbSpell.Clear();
                    }
                    else
                    {
                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
