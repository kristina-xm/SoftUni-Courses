namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;
    public class Pet : IBirthdate
    {
        private string birthdate;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string BirthDate
        {
            get => birthdate;
            set => birthdate = value;
        }
    }
}
