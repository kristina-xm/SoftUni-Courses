namespace Raiding.Core
{

    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        public Engine()
        {
           
        }

        public void Start()
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                try
                {
                    if (heroes.Count == n)
                    {
                        break;
                    }

                    string name = Console.ReadLine();
                    string type = Console.ReadLine();


                    if (type == "Druid")
                    {
                        Druid durid = new Druid(name);
                        heroes.Add(durid);
                    }
                    else if (type == "Paladin")
                    {
                        Paladin paladin = new Paladin(name);
                        heroes.Add(paladin);
                    }
                    else if (type == "Rogue")
                    {
                        Rogue rogue = new Rogue(name);
                        heroes.Add(rogue);
                    }
                    else if (type == "Warrior")
                    {
                        Warrior warrior = new Warrior(name);
                        heroes.Add(warrior);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                continue;
            }

            int powerToBeat = int.Parse(Console.ReadLine());

            int heroesPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }

            if (heroesPower >= powerToBeat)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
