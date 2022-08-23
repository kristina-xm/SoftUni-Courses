namespace Gym.Repositories
{
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        public List<IEquipment> equipments;

        public EquipmentRepository()
        {
            equipments = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => equipments;

        public void Add(IEquipment model)
        {
            equipments.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            var equipment = equipments.FirstOrDefault(e => e.GetType().Name == type);

            if (equipment != null)
            {
                return equipment;
            }
            return null;
        }

        public bool Remove(IEquipment model)
        {
            var equipment = equipments.FirstOrDefault(e => e.Price == model.Price && e.Weight == model.Weight);

            if (equipment != null)
            {
               equipments.Remove(equipment);
                return true;
            }
            return false;
        }
    }
}
