using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    //货物类 
    enum goodstype: int
        {
            wine,gun,fish
        }
    class Goods
    {
        private goodstype type;
        private double price;

        public goodstype Type { get { return type; } }
        public double Price { get { return price; } }

        public Goods(goodstype type,double price)
        {
            this.type = type;
            this.price = price;
        }
        public override string ToString()
        {
            return Type+"";
        }
    }
}
