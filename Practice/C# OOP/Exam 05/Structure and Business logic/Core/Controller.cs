namespace Easter.Core
{
    using Easter.Core.Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops;
    using Easter.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private BunnyRepository bunniesData;
        private EggRepository eggsData;

        public Controller()
        {
            bunniesData = new BunnyRepository();
            eggsData = new EggRepository();
        }

       
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            bunniesData.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunnyNeeded = bunniesData.FindByName(bunnyName);

            if (bunnyNeeded == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            else
            {
                var dye = new Dye(power);
                bunnyNeeded.Dyes.Add(dye);

                return $"Successfully added dye with power {power} to bunny {bunnyName}!";
            }
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);

            eggsData.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        List<IEgg> coloredEggs = new List<IEgg>();
        public string ColorEgg(string eggName)
        {
            var eggForColor = eggsData.FindByName(eggName);

            var suitableBunnies = bunniesData.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();
            
            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            var workshop = new Workshop();

            foreach (var bunny in suitableBunnies)
            {
                if (eggForColor.EnergyRequired <= 0)
                {
                    break;
                }

             
                while (bunny.Energy > 0)
                {
                    if (eggForColor.EnergyRequired <= 0)
                    {
                        break;
                    }
                    workshop.Color(eggForColor, bunny);
                    
                    if (bunny.Energy <= 0)
                    {
                        bunniesData.Remove(bunny);
                        break;
                    }
                }
                
            }

         

            if (eggForColor.IsDone())
            {
                coloredEggs.Add(eggForColor);
                return $"Egg {eggName} is done.";
          
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
                sb.AppendLine("Bunnies info:");

            foreach(var bunny in bunniesData.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
