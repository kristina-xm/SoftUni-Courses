using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
            this.hired = false;
        }

        public override string ToString()
        {
            return $"-Renovator: {Name}{Environment.NewLine}--Specialty: {Type}{Environment.NewLine}--Rate per day: {Rate} BGN";
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public double Rate { get => rate; set => rate = value; }
        public int Days { get => days; set => days = value; }
        public bool Hired { get => hired; set => hired = value; }
    }
}
