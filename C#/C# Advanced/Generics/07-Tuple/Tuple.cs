using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Tuple<TFirst, TSecond> 
    {
        public Tuple(TFirst firstEl, TSecond secondEl)
        {
            First = firstEl;
            Second = secondEl;
        }
        
        public TFirst First { get; private set; }
        public TSecond Second { get; private set;}

        public override string ToString()
        {
            return $"{First} -> {Second}";
        }
    }
}
