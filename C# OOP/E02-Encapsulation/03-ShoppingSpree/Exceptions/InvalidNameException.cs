namespace ShoppingSpree.Exceptions
{
    using System; 
    public class InvalidNameException : Exception
    {
        private const string message = "Name cannot be empty";

        public InvalidNameException() : base(message)
        {

        }
    }
}
