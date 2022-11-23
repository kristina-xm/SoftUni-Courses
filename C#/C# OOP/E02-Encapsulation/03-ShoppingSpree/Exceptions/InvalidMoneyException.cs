namespace ShoppingSpree.Exceptions
{
    using System;
    public class InvalidMoneyException : Exception
    {
        private const string message = "Money cannot be negative";

        public InvalidMoneyException() : base(message)
        {

        }
    }
}
