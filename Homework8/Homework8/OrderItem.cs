using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Homework11
{
    //订单明细类
    [Serializable]
    public class OrderItem
    {
        public string Id { get; set; }

        public string GoodsId { get; set; }
        public string GoodsType { get { return Goods.Type; } /*set { Goods.Type = value; }*/ }
        [ForeignKey("GoodsId")]
        public Goods Goods { get; set; }

        public int OrderId { get; set; }

        public int quantity;    //货物数量
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public double GoodPrice { get { return Goods == null ? 0 : Goods.Price; } set { } }
        public double Itemprice { get { return Goods == null ? 0 : Quantity * GoodPrice; } set { } }

        public OrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }
        public OrderItem(Goods goods, int quantity) : this()
        {
            this.Goods = goods;
            this.quantity = quantity;
           // this.Itemprice = quantity * goods.Price;
        }

       /* public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.Goods.Equals(Goods) && m.quantity == quantity && m.Itemprice == Itemprice;
        }*/
        public override string ToString()
        {
            string result = "商品:" + Goods + "\n" + "购买数量:" + quantity + ",     该项价格为" + Itemprice;
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
