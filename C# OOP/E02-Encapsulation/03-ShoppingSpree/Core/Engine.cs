namespace ShoppingSpree.Core
{
    using ShoppingSpree.Core;
    using ShoppingSpree.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using ShoppingSpree.Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            try
            {
                List<Person> peopleBuying = new List<Person>();

                Dictionary<string, decimal> peopleAndProducts = new Dictionary<string, decimal>();

                Dictionary<string, decimal> productsAndTheirPrice = new Dictionary<string, decimal>();

                //input: Name=Money;Name2=Money2;NameN=MoneyN
                string[] people = Console.ReadLine().Split(";");


                foreach (string person in people)
                {
                    string[] information = person.Split("=");
                    string name = information[0];
                    decimal money = decimal.Parse(information[1]);


                    //Create an instance of a person who will buy products
                    Person buyer = new Person(name, money);
                    peopleBuying.Add(buyer);


                    //Store the information about the money of every person
                    peopleAndProducts.Add(buyer.Name, money);

                }

                //Same logic for products
                string[] products = Console.ReadLine().Split(";");

                foreach (string p in products)
                {
                    string[] information = p.Split("=");
                    string name = information[0];
                    decimal price = decimal.Parse(information[1]);


                    //Create an instance of a product
                    Product product = new Product(name, price);


                    //Store the information about the price of every product
                    productsAndTheirPrice.Add(product.Name, price);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string personName = command.Split(" ")[0];
                    string productName = command.Split(" ")[1];

                    //If the person has enough money to buy the product
                    if (peopleAndProducts[personName] >= productsAndTheirPrice[productName])
                    {
                        //Add the bought product to the collection of this person
                        var person = peopleBuying.Find(p => p.Name == personName);
                        person.Products.Add(productName);

                        //Reduce money after purchase
                        peopleAndProducts[personName] -= productsAndTheirPrice[productName];
                        this.writer.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        this.writer.WriteLine($"{personName} can't afford {productName}");
                    }

                    command = Console.ReadLine();
                }

                foreach (var person in peopleBuying)
                {
                    if (person.Products.Count != 0)
                    {
                        this.writer.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                    }
                    else
                    {
                        this.writer.WriteLine($"{person.Name} - Nothing bought");
                    }

                }
            }
            catch (InvalidNameException ine)
            {
                this.writer.WriteLine(ine.Message);
                return; // In the description is written: Break the program with the appropriate message
            }
            catch(InvalidMoneyException ime)
            {
                this.writer.WriteLine(ime.Message);
                return; // In the description is written: Break the program with the appropriate message
            }
            
        }
    }
}
