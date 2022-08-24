namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class HappyBunny : Bunny
    {
        private const int energy = 100;
        public HappyBunny(string name) : base(name, energy)
        {
        }

        public override void Work()
        {
            this.Energy -= 10;
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
