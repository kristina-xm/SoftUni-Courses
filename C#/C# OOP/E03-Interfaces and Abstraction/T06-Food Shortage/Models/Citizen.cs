namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;

    public class Citizen : IIdentifiable, IBirthdate, IPerson, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthDate;
        private int food;

        public Citizen(string name, int food)
        {
            this.Name = name;
            this.Food = food;
        }
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Id 
        { 
            get => id; 
            set => id = value; 
        }
        public string BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }
        public int Food
        {
            get => food;
            set => food = value;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
