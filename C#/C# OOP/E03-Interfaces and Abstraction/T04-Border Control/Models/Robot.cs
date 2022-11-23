namespace BorderControl.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using BorderControl.Models.Interfaces;
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
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
