

namespace PersonInfo
{

    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputName = Console.ReadLine();
            int inputAge = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();

            Citizen citizen = new Citizen(inputName, inputAge, id, birthdate);

            Console.WriteLine(citizen.ToString());
        


        }
    }
}
