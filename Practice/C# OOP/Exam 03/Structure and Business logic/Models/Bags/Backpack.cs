namespace SpaceStation.Models.Bags
{
    using SpaceStation.Models.Bags.Contracts;
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private List<string> bags;

        public Backpack()
        {
            bags = new List<string>();
        }
        public ICollection<string> Items => bags;
    }
}
