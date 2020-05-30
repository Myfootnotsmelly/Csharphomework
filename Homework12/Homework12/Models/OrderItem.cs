using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework12.Models
{
    public class OrderItem
    {

        public string Id { get; set; }
         
        public int OrderId { get;set; }

        public int Quantity { get; set; }

        public double GoodPrice { get; set; }

        public double Itemprice { get { return Quantity*GoodPrice; } }



    }
}
