namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;
    public class Rebel : IPerson, IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int food)
        {
            this.Name = name;
            this.Food = food;
        }

        public string Group
        {
            get => group;
            set => group = value;
        }

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }
        public int Age 
        { 
            get => age; 
            set => age = value; 
        }
        public int Food 
        { 
            get => food; 
            set => food = value; 
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
