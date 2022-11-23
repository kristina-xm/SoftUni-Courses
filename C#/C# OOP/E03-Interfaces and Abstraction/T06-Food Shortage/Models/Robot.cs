namespace BorderControl.Models
{
    
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
    }
}
