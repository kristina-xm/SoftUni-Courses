namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using ShoppingSpree.Exceptions;
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<string>();
        }

        public string Name 
        { 
            get 
            { 
                return name; 
            } 
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new InvalidNameException();
                }
                else
                {
                    name = value;
                }
            
            } 
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidMoneyException();
                }
                else
                {
                    money = value;
                }
           
            }
        }

        public List<string> Products
        {
            get
            {
                return products;
            }
            set 
            { 
                products = value; 
            }
        }
    }
}
