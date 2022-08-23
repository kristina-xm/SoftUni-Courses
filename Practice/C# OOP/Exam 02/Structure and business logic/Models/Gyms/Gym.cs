namespace Gym.Models.Gyms
{
    using Equipment.Contracts;
    using Athletes.Contracts;
    using Gyms.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public double EquipmentWeight => this.equipments.Sum(e => e.Weight);

        ICollection<IEquipment> IGym.Equipment => this.equipments;
        ICollection<IAthlete> IGym.Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count < capacity)
            {
                this.athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var ath in athletes)
            {
                ath.Exercise();
            }
        }

        public string GymInfo()
        {
            if (athletes.Count > 0)
            {
                return $"{this.Name} is a {this.GetType().Name}:{Environment.NewLine}Athletes: {string.Join(", ", athletes.Select(a => a.FullName))}{Environment.NewLine}Equipment total count: {equipments.Count}{Environment.NewLine}Equipment total weight: {this.EquipmentWeight:f2} grams";
            }
            
            return $"{this.Name} is a {this.GetType().Name}:{Environment.NewLine}Athletes: No athletes{Environment.NewLine}Equipment total count: {equipments.Count}{Environment.NewLine}Equipment total weight: {this.EquipmentWeight:f2} grams";

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            var athleteToRemove = athletes.FirstOrDefault(a => a.FullName == athlete.FullName);
            
            if (athleteToRemove != null)
            {
                athletes.Remove(athleteToRemove);
                return true;
            }
            return false;
        }
    }
}
