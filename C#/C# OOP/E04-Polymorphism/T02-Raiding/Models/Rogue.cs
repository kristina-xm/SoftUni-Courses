using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private string name;
        private const int power = 80;

        public Rogue(string name)
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
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
