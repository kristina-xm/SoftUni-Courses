namespace Raiding
{
    public class Druid : BaseHero
    {
        private string name;
        private const int power = 80;

        public Druid(string name)
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
