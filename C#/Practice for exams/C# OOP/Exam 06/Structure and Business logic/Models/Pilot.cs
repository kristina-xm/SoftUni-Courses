using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    using Formula1.Utilities;
    using System;
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;
        private int numOfWins = 0;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format("Invalid pilot name: {0}.", value));
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
               return car;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(String.Format("Pilot car can not be null."));
                }
                car = value;
            }
        }

        public int NumberOfWins => numOfWins;

        public bool CanRace => canRace;

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
            this.numOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
