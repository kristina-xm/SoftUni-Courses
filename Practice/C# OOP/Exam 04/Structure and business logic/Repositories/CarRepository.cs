namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => cars;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            cars.Add(model);
        }

        public ICar FindBy(string property)
        {
            var car = cars.FirstOrDefault(c => c.VIN == property);

            if (car == null)
            {
                return null;
            }
            return car;
        }

        public bool Remove(ICar model)
        {
            var car = cars.FirstOrDefault(c => c.VIN == model.VIN);

            if (car != null)
            {
                cars.Remove(car);
                return true;
            }
            return false;
        }
    }
}
