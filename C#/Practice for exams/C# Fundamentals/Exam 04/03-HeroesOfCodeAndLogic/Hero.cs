using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfCodeAndLogic
{
    public class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.HP = hp;
            this.MP = mp;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

    }
}
