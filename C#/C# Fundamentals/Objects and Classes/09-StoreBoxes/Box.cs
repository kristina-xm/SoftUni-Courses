using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06StroreBoxes
{
    public class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public decimal PriceBox
        {
            get
            {
                return this.Quantity * this.Item.Price;
            }
        }
    }
}
