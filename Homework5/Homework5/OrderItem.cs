using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    //订单明细类
    class OrderItem
    {
        private Goods goods;     //货物
        private int quantity;    //货物数量
        private double itemprice;//订单中每项价格

        public Goods thisgoods { get { return goods;} }
        public int Quantity { get { return quantity; } }
        public double Itemprice { get { return itemprice; } }

        public OrderItem(Goods goods,int quantity)
        {
            this.goods = goods;
            this.quantity = quantity;
            this.itemprice = quantity * goods.Price;
        }

        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.goods == goods && m.quantity == quantity && m.itemprice == itemprice ;
        }
        public override string ToString()
        {
            Console.Write("商品:"+goods);
            return "购买数量:"+quantity+",     该项价格为" + itemprice;
        }
    }
}
