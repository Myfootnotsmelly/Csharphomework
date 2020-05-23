using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    //货物类 
    [Serializable]
    public enum goodstype: int
        {
            wine,gun,fish
        }
    [Serializable]
    public class Goods
    {
        public string Id { get; set; }
        public goodstype Type { get; }
        public double Price { get; }

        public Goods()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Goods(goodstype type):this()
        {
            this.Type = type;
        }
        public Goods(goodstype type,double price)
        {
            this.Type = type;
            this.Price = price;
        }
        public override string ToString()
        {
            return Type+"";
        }
        public override bool Equals(object obj)
        {
            Goods m = obj as Goods;
            return m != null && m.Type == Type;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
