using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Car
    {
        private string model;
        private EngineClass engine;
        private CargoClass cargo;
        private TiresCollection tires;

        public Car(string model, EngineClass engine, CargoClass cargo, TiresCollection tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
       
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public EngineClass Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public CargoClass Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public TiresCollection Tires
        {
            get { return tires; }
            set { tires = value; }
        }

    }
}
