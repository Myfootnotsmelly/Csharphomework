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
        public int quantity;    //货物数量
        public double itemprice;//订单中每项价格

        public string Id { get; set; }  

        public string GoodsId { get; set; }   
        public goodstype GoodsType { get { return Goods.Type; }  }
        [ForeignKey("GoodsId")]
        public Goods Goods { get; set; }

        public int OrderId { get; }

        public int Quantity { get { return quantity; }set { quantity = value;/* Itemprice = quantity * Goods.Price;*/ } }
        public double GoodPrice { get { return Goods.Price; } }
        public double Itemprice { get { return itemprice; } set { itemprice = value; } }

        public OrderItem() {
            Id = Guid.NewGuid().ToString();
        }
        public OrderItem(Goods goods,int quantity):this()
        {
            this.Goods = goods;
            this.quantity = quantity;
            this.itemprice = quantity * goods.Price;
        }

        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.Goods.Equals(Goods) && m.quantity == quantity && m.itemprice == itemprice ;
        }
        public override string ToString()
        {
            string result = "商品:" + Goods+ "\n"+ "购买数量:" + quantity + ",     该项价格为" + itemprice;
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
