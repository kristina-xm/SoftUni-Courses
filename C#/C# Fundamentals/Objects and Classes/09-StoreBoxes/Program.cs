using System;
using System.Collections.Generic;
using System.Linq;

namespace P06StroreBoxes
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split();
                string serialNumber = tokens[0];
                string name = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal price = decimal.Parse(tokens[3]);
                
                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    
                    Item = new Item()
                    {
                        Name = name,
                        Price = price
                    },
                    
                    Quantity = quantity,
                };

                boxes.Add(box);

                line = Console.ReadLine();
            }

            List<Box> orderedBoxes = boxes
                    .OrderByDescending(b => b.PriceBox)
                    .ToList();

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }
}
