using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    internal class Ski
    {
        private string manufacturer;
        private string model;
        private int year;

        public Ski(string Manufacturer, string Model, int Year)
        {
            this.manufacturer = Manufacturer;
            this.model = Model;
            this.year = Year;
        }


        public override string ToString()
        {
            return $"{this.Manufacturer} - {this.Model} - {this.Year}";
        }

        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
    }
}
