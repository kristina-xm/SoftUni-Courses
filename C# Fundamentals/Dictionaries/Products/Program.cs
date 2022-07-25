using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productsInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, double> products = new Dictionary<string, double>();

            Dictionary<string, double> amounts = new Dictionary<string, double>();

            int countForRepetition = 1;

            List<string> list = new List<string>();

            while (productsInformation[0] != "buy")
            {
               
                string name = productsInformation[0];
                double price = double.Parse(productsInformation[1]);
                double quantity = double.Parse(productsInformation[2]);

                list.Add(name);
                list.Add(quantity.ToString());

                double sum = 0;

                if (products.ContainsKey(name))
                {
                    
                    if (countForRepetition > 1)
                    {

                        var item2 = (from d in list
                                     where d == name
                                     select name).LastOrDefault();
                        
                       int index = list.IndexOf(item2);
                            
                    
                        
                        var item3 = double.Parse(list.ElementAt(index + 1));
                        quantity += item3;
                        sum += price * quantity;
                        amounts[name] = sum;

                        productsInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        continue;
                    }

                    var item = (from d in products
                                where d.Key == name
                                select d.Value).FirstOrDefault();

                    countForRepetition++;
                    quantity += item;
                    sum += price * quantity;
                    amounts[name] = sum;
                    
                   

                }
                if (!products.ContainsKey(name))
                {
                    products.Add(name, quantity);
                    sum += price * quantity;
                    amounts[name] = sum;
                }

                productsInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var item in amounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
            
        }
    }
}
