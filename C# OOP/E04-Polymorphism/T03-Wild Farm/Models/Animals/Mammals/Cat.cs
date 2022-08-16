
using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        private const double CatMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Vegetable), typeof(Meat)};

        protected override double WeightMultiplier => CatMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
