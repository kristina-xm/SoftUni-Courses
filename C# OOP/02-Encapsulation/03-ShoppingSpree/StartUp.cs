namespace ShoppingSpree
{
    using ShoppingSpree.Core;
    using ShoppingSpree.IO;
    using ShoppingSpree.IO.Interfaces;
    using System;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
