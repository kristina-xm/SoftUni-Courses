using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class EngineClass
    {
        public EngineClass(double speed, double power)
        {
            Speed = speed;
            Power = power;
        }

        private double speed;
        private double power;

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public double Power
        {
            get { return power; }
            set { power = value; }
        }
    }
}
