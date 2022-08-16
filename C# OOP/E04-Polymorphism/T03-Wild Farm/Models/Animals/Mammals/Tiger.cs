
namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat)};

        protected override double WeightMultiplier => TigerWeightMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
