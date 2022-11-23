namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Weightlifter : Athlete
    {
        private const int initialStamina = 50;
        private const int increaseStamina = 10;

        private int currStamina = initialStamina;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, initialStamina)
        {

        }

        public override void Exercise()
        {
            currStamina += increaseStamina;

            if (currStamina > 100)
            {
                currStamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
        }
    }
}
