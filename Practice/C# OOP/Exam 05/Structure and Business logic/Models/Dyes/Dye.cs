﻿namespace Easter.Models.Dyes
{
    using Easter.Models.Dyes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get { return power; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                power = value;
            }
        }

        public bool IsFinished() => this.Power == 0;

        public void Use()
        {
            this.Power -= 10;
            if (this.Power < 0)
            {
                this.Power = 0;
            }
        }
    }
}
