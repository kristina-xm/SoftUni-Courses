using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm.Exceptions
{
    public class InvalidAgeException : Exception
    {
        private const string message = "Age should be between 0 and 15.";

        public InvalidAgeException() : base(message)
        {

        }
    }
}
