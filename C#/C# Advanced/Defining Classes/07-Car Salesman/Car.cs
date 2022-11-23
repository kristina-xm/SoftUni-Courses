using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Car
    {
        private string model;
        private EngineClass engine;
        private int weight;
        private string color;

        public Car(string model, EngineClass engine)
        {
            Model = model;
            Engine = engine;
            Color = "n/a";
        }

        public Car(string model, EngineClass engine, string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
           
        }

        public Car(string model, EngineClass engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = "n/a";
        }

        public Car(string model, EngineClass engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
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

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
