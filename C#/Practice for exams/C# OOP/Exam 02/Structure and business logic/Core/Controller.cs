namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private List<IGym> gyms;
        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            IGym gym = null;
            
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            IEquipment equip = null;

            if (equipmentType == "BoxingGloves")
            {
                equip = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equip = new Kettlebell();
            }

            equipments.Add(equip);
            return $"Successfully added {equipmentType}.";
        }


        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipment = equipments.Models.FirstOrDefault(e => e.GetType().Name == equipmentType);

            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (equipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            equipments.Remove(equipment);
            gym.Equipment.Add(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            if (athleteType == "Boxer" && gym.GetType().Name != "BoxingGym")
            {
                return "The gym is not appropriate.";
            }
            else if (athleteType == "Weightlifter" && gym.GetType().Name != "WeightliftingGym") 
            {
                return "The gym is not appropriate.";
            }

            IAthlete athlete = null;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            if (gym.Athletes.Count < gym.Capacity)
            {
                gym.Athletes.Add(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            return $"Not enough space in the gym.";


        }
        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            foreach (var ath in gym.Athletes)
            {
                ath.Exercise();
            }

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            var weight = gym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {weight:f2} grams.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < gyms.Count; i++)
            {
                if (i == gyms.Count - 1)
                {
                    sb.Append(gyms[i].GymInfo());
                    break;
                }

                sb.AppendLine(gyms[i].GymInfo());
            }
            
            return sb.ToString();
        }

    }
}
