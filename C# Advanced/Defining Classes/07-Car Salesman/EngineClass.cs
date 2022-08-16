using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class EngineClass
    {
        private string engineModel;
        private int power;
        private int displacement;
        private string efficiency;

        public EngineClass(string eModel, int power)
        {
            EngineModel = eModel;
            Power = power;
            Efficiency = "n/a";
        }

        public EngineClass(string eModel, int power, int displacement)
        {
            EngineModel = eModel;
            Power = power;
            Displacement = displacement;
            Efficiency = "n/a";
        }
        public EngineClass(string eModel, int power, string efficiency)
        {
            EngineModel = eModel;
            Power = power;
            Efficiency = efficiency;
            
        }

        public EngineClass(string eModel, int power, int displacement, string efficiency)
        {
            EngineModel = eModel;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public string EngineModel
        {
            get { return engineModel; }
            set { engineModel = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
