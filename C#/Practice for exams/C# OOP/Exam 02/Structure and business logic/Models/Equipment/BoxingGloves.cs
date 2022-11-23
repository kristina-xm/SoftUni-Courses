namespace Gym.Models.Equipment
{
    using System;
    public class BoxingGloves : Equipment
    {
        private const double weight = 227;
        private const decimal price = 120;

        public BoxingGloves() : base(weight, price)
        {
        }
    }
}
