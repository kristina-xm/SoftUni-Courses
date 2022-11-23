using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    internal class SkiRental
    {
        private List<Ski> data;
        private string name;
        private int capacity;

        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            this.name = name;
            this.capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (this.Data.Count < this.Capacity)
            {
                this.Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var ski = Data.Find(x => x.Model == model && x.Manufacturer == manufacturer);
            if (ski != null)
            {
                Data.Remove(ski);   
                return true;
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            if (Data.Count != 0)
            {
                return this.Data.OrderByDescending(x => x.Year).FirstOrDefault();
            }
            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var ski = Data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski != null)
            {
                return ski;
            }
            return null;
        }

        public int Count
        {
            get => this.Data.Count;
        }

        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.Data)}";
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        internal List<Ski> Data { get => data; set => data = value; }
    }
}
