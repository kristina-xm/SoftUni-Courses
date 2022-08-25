﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }
        public string Model 
        { 
            get 
            { 
                return model; 
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(String.Format("Invalid car model: {0}.", value));
                }
                model = value; 
            }
        }

        public int Horsepower
        {
            get
            {
                return horsePower;
            }
            set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(String.Format("Invalid car horsepower: {0}.", value));
                }
                horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get
            {
                return engineDisplacement;
            }
            set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(String.Format("Invalid car engine displacement: {0}.", value));
                }
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return this.EngineDisplacement / this.Horsepower * laps;
        }
    }
}
