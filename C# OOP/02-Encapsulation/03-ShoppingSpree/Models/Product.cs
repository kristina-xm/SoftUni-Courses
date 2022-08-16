namespace ShoppingSpree
{
    using ShoppingSpree.Exceptions;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost 
        { 
            get 
            { 
                return cost; 
            }
            set 
            {
                if (value < 0)
                {
                    throw new InvalidMoneyException();
                }
                else
                {
                    cost = value;
                }
            
            }
        }
    }
}
