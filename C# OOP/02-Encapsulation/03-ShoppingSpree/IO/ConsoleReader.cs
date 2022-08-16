namespace ShoppingSpree.IO
{
    using ShoppingSpree.IO.Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
