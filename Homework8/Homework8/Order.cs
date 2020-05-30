using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework11
{
    [Serializable]
    public class Order
    {
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }         //顾客 
        public string Cname { get { return   (Customer != null) ? Customer.Name : ""; } set { Customer.Name = value; } }//获得该订单所属顾客名

        public int OrderId { get; set; }               //订单号    

        public List<OrderItem> orderItemList { get; set; }     //订单明细   
        public double Totalprice { get; set; }         //订单总价



        public Order()
        {
            Customer = new Customer();
            orderItemList = new List<OrderItem>();
        }

        public Order(int id, Customer customer):this()
        {
            OrderId = id;
            Customer = customer;
            Totalprice = 0;
        }

        public void updateTotalprice()
        {
            double temp_sum = 0;
            foreach (OrderItem x in orderItemList)
            {
                temp_sum += x.Itemprice;
            }
            this.Totalprice = temp_sum;
        }
        //修改订单时调用以下对订单明细的操作
        public void addOrderItem(OrderItem newOI)//在订单中添加新项
        {
            /* foreach(OrderItem x in orderItemList)
             {
                 if (x.Equals(newOI))
                     throw new Exception("已存在相同订单项！");     
             }*/
            if (orderItemList.Contains(newOI))
                throw new ApplicationException("添加错误：订单项已经存在!");
            orderItemList.Add(newOI);
            updateTotalprice();
        }
        public void deleteOrderItem(OrderItem todelOI)
        {
            orderItemList.Remove(todelOI);
            updateTotalprice();
        }
        /*
                public void exportOrderItem()
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderItem>));
                    using (FileStream fs = new FileStream("order.xml", FileMode.Create))
                    {
                        xmlSerializer.Serialize(fs, orderItemlist);
                    }
                }


               /* public void deleteOrderItem(int index)//在订单中删除某项
                {
                    if (orderItemlist[index] != null)
                    {
                        orderItemlist.RemoveAt(index);
                        updateTotalprice();
                    }
                    else
                        throw new Exception("该订单不存在该项明细!");
                }*/





        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            bool orderItemlist_equal = true;
            for (int i = 0; i < m.orderItemList.Count; i = i + 1)
            {
                orderItemlist_equal = orderItemlist_equal && (m.orderItemList[i].Equals(orderItemList[i]));
            }
            return m != null && m.Customer.Equals(Customer) && orderItemlist_equal && m.Totalprice == Totalprice;
        }
        public override string ToString()
        {
            string result = "客户:" + Customer + "\n" + "订单号:" + OrderId + "\n";
            foreach (OrderItem a in orderItemList)
            {
                //Console.WriteLine(a);
                result += a + "\n";
            }
            result += "该订单总计:" + Totalprice;
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
