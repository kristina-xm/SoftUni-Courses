namespace BorderControl
{
    using BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //List<string> detained = new List<string>();

            //string command = Console.ReadLine();

            //while (command != "End")
            //{
            //    string[] input = command.Split(' ');

            //    if (input[0] == "Citizen")
            //    {
            //        string identity = input[4];
            //        detained.Add(identity);
            //    }
            //    if (input[0] == "Pet")
            //    {
            //        string identity = input[2];
            //        detained.Add(identity);
            //    }
            //    else if (input[0] == "Robot")
            //    {
            //        command = Console.ReadLine();
            //        continue;
            //    }

            //    command = Console.ReadLine();
            //}

            //string validation = Console.ReadLine();

            //Console.WriteLine(string.Join("\n", CheckIdentity(detained, validation)));

            int n = int.Parse(Console.ReadLine());

            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];  

                if (info.Length == 4)
                {
                    Citizen citizen = new Citizen(name, 0);
                    citizens.Add(citizen);
                }
                else if (info.Length == 3)
                {
                    Rebel rebel = new Rebel(name, 0);
                    rebels.Add(rebel);
                }
            }


            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command.Contains(" "))
                {
                    command = command.Replace(" ", "");
                }
           
                if (citizens.Any(c => c.Name == command.ToString()))
                {
                    var currCitizen = citizens.First(c => c.Name == command.ToString());
                    currCitizen.BuyFood();
                }
                else if (rebels.Any(r => r.Name == command.ToString()))
                {
                    var currRebel = rebels.First(c => c.Name == command.ToString());
                    currRebel.BuyFood();
                }

                command = Console.ReadLine();
            }

            int finalAmountOfFood = 0;

            foreach (var c in citizens)
            {
                finalAmountOfFood += c.Food;
            }

            foreach (var r in rebels)
            {
                finalAmountOfFood += r.Food;
            }

            Console.WriteLine(finalAmountOfFood);
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
