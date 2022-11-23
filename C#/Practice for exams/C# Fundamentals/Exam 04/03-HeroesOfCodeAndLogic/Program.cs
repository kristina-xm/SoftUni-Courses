using System;
using System.Collections.Generic;

namespace HeroesOfCodeAndLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] heroesInput = Console.ReadLine().Split(" ");

                string heroName = heroesInput[0];
                int hp = int.Parse(heroesInput[1]);
                int mp = int.Parse(heroesInput[2]);

                if (hp > 100)
                {
                    hp = 100;
                }
                if (mp > 200)
                {
                    mp = 200;
                }

                Hero hero = new Hero(heroName, hp, mp);
                heroes.Add(hero);
            }

            string[] cmd = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "End")
            {
                if (cmd[0] == "CastSpell")
                {
                    string heroName = cmd[1];
                    int mpNeeded = int.Parse(cmd[2]);
                    string spellName = cmd[3];

                    foreach (var item in heroes)
                    {
                        if (heroName == item.Name)
                        {
                            if (item.MP >= mpNeeded)
                            {
                                item.MP -= mpNeeded;
                                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {item.MP} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                            }
                            break;
                        }
                    }
                }
                else if (cmd[0] == "TakeDamage")
                {
                    string heroName = cmd[1];
                    int damage = int.Parse(cmd[2]);
                    string attacker = cmd[3];

                    foreach (var item in heroes)
                    {
                        if (item.Name == heroName)
                        {
                            item.HP -= damage;
                            if (item.HP > 0)
                            {
                                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {item.HP} HP left!");
                            }
                            else
                            {
                                heroes.Remove(item);
                                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            }
                            break;
                        }
                    }
                }
                else if (cmd[0] == "Recharge")
                {
                    string heroName = cmd[1];
                    int amountMP = int.Parse(cmd[2]);

                    foreach (var item in heroes)
                    {
                        if (item.Name == heroName)
                        {
                            int totalMP = item.MP;
                            totalMP += amountMP;
                            if (totalMP > 200)
                            {
                                amountMP = 200 - item.MP;
                                item.MP = 200;
                                Console.WriteLine($"{heroName} recharged for {amountMP} MP!");
                                break;
                            }
                            item.MP = totalMP;
                            Console.WriteLine($"{heroName} recharged for {amountMP} MP!");
                            break;
                        }
                    }
                }
                else if (cmd[0] == "Heal")
                {
                    string heroName = cmd[1];
                    int amountHP = int.Parse(cmd[2]);

                    foreach (var item in heroes)
                    {
                        if (item.Name == heroName)
                        {
                            int totalHP = item.HP;
                            totalHP += amountHP;
                            if (totalHP > 100)
                            {
                                amountHP = 100 - item.HP;
                                item.HP = 100;
                                Console.WriteLine($"{heroName} healed for {amountHP} HP!");
                                break;
                            }
                            item.HP = totalHP;
                            Console.WriteLine($"{heroName} healed for {amountHP} HP!");
                            break;
                        }
                    }
                }
                cmd = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join("\n", heroes));
        }
    }
}
