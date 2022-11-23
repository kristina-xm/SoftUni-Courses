using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePianist
{
    public class Music
    {
        public Music(string name, string composer, string key)
        {
            this.Piece = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
