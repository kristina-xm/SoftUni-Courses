namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Motorcycle motor = new Motorcycle(450, 80);
            motor.Drive(20);
        }
    }
}
