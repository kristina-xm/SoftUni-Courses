namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;

    public class Citizen : IIdentifiable, IBirthdate
    {
        private string name;
        private int age;
        private string id;
        private string birthDate;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public int Age
        {
            get { return this.Age; }
            set { this.Age = value; }
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
    }
}
