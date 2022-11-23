using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private string name;
        private const int power = 100;

        public Paladin(string name)
        {
            this.Name = name;
        }

        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override int Power => power;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
