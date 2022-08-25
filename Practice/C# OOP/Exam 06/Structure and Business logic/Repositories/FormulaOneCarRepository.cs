using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => models;

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            var car = this.models.FirstOrDefault(c => c.Model == name);
            if (car == null)
            {
                return null;
            }
            return car;
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (this.models.Any(m => m.Equals(model)))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
