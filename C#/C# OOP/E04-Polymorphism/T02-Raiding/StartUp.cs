namespace Raiding
{
    using Raiding.Core;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
