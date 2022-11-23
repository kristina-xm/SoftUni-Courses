namespace BorderControl.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using BorderControl.Models.Interfaces;

    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

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

        //public string CheckIdentity(string identity)
        //{
        //    int verifiyNumsLength = identity.Length;

        //    List<char> numsOfId = this.Id.ToList();

        //    int numsToSkip = (numsOfId.Count - 1) - verifiyNumsLength;

        //    if (numsOfId.Skip(numsToSkip).ToString() == identity)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        return this.Id;
        //    }
        //}
    }
}
