namespace AnimalFarm.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidNameException : Exception
    {
        internal const string message = "Name cannot be empty.";
        public InvalidNameException() : base(message) 
        {
            
        }

    }
}
