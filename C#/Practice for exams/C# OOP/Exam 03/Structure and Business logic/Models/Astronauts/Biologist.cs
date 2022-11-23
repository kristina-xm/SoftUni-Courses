namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double biologistOxygen = 70.00;
        public Biologist(string name)
            : base(name, biologistOxygen)
        {
        }

        //public override bool CanBreath => Oxygen >= 5.00;

        public override void Breath()
        {
            if (Oxygen - 5 <= 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 5;
            }
        }
        //private const double initialOxygen = 70;

        //public Biologist(string name) : base(name, initialOxygen)
        //{

        //}

        //public override bool CanBreath => Oxygen >= 5.00;

        //public override void Breath()
        //{
        //    base.Breath();
        //    if (this.Oxygen <= 0)
        //    {
        //        this.Oxygen = 0;
        //    }
        //    else
        //    {
        //        this.Oxygen -= 5;
        //    }


        //}
    }
}
