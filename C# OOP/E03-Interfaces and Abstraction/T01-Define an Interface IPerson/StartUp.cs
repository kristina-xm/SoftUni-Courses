

namespace PersonInfo
{

    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputName = Console.ReadLine();
            int inputAge = int.Parse(Console.ReadLine());

            Citizen citizen = new Citizen(inputName, inputAge);

            Console.WriteLine(citizen.ToString());
        


        }
    }
}
