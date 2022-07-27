using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        private string name;
        private int neededRenovators;
        private string project;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.renovators = new List<Renovator>();
            this.name = name;
            this.neededRenovators = neededRenovators;
            this.project = project;
        }

        public List<Renovator> Renovators { get => renovators; set => renovators = value; }
        public string Name { get => name; set => name = value; }
        public int NeededRenovators { get => neededRenovators; set => neededRenovators = value; }
        public string Project { get => project; set => project = value; }


        public int Count { get => Renovators.Count; }

        public string AddRenovator(Renovator renovator)
        {
            if (Renovators.Count < neededRenovators)
            {
                if (renovator.Name == null || renovator.Type == null || renovator.Name == string.Empty || renovator.Type == string.Empty)
                {
                    return $"Invalid renovator's information.";
                }
            }
            else
            {
                return $"Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return $"Invalid renovator's rate.";
            }
            else
            {
                Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            var renov = Renovators.Find(x => x.Name == name);
            
            if (renov != null)
            {
                Renovators.Remove(renov);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var renovatorToRemove = Renovators.Find(x => x.Type == type);
            var renovatorsToRemove = Renovators.FindAll(x => x.Type == type);

            if (renovatorsToRemove.Count > 0)
            {
                Renovators.RemoveAll(renovatorToRemove => renovatorToRemove.Type == type);
                return renovatorsToRemove.Count;
            }
            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            var renovator = Renovators.Find(x => x.Name == name);

            if (renovator != null)
            {
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var renovators = Renovators.FindAll(x =>x.Days >= days);
            return renovators;
        }

        public string Report()
        {
            var notHiredRenovators = Renovators.FindAll(x => x.Hired == false);
            return $"Renovators available for Project {Project}:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, notHiredRenovators)}";
        }
    }
}
