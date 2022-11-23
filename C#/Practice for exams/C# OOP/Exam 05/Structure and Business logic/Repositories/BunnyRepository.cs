namespace Easter.Repositories
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class BunnyRepository : IRepository<IBunny>
    {
        public List<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunnies;

        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }

        public IBunny FindByName(string name) => bunnies.FirstOrDefault(b => b.Name == name);
        

        public bool Remove(IBunny model)
        {
            var bunnyToRemove = bunnies.FirstOrDefault(b => b.Name == model.Name);

            if (bunnyToRemove != null)
            {
                bunnies.Remove(bunnyToRemove);
                return true;
            }
            return false;
        }
    }
}
