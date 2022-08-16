namespace WildFarm.Exceptions
{
    using System;
    public class FoodNotPreferredException : Exception
    {
        //private const string DefMessage = ""
        public FoodNotPreferredException(string message) : base(message)    
        {

        }
    }
}
