using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Order
    {
        private Customer customer;                          //顾客
        private List<OrderItem> orderItemlist;              //订单明细
        private int id;                                     //订单号
        private double totalprice;                          //订单总价
       
        public double Totalprice { get { return totalprice; } }
        public int Id { get { return id; } }
        public string Cname {get { return customer.Name; } }//获得该订单所属顾客名
        public Customer Customer { get { return customer; } }
        public List<OrderItem> OrderItemList { get { return orderItemlist; } }

        public Order(int id,Customer customer)
        {
            this.id = id;
            this.customer = customer;
            this.totalprice = 0;
            this.orderItemlist = new List<OrderItem>();
        }

        public void updateTotalprice()
        {
            double temp_sum = 0;
            foreach (OrderItem x in orderItemlist)
            {
                temp_sum += x.Itemprice;
            }
            this.totalprice = temp_sum;
        }
        //修改订单时调用以下对订单明细的操作
        public void addOrderItem(OrderItem newOI)//在订单中添加新项
        {
            foreach(OrderItem x in orderItemlist)
            {
                if (x.Equals(newOI))
                    throw new Exception("已存在相同订单项！");     
            }
            orderItemlist.Add(newOI);
            updateTotalprice(); 
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
            bool orderItemlist_equal=true;
            for(int i=0;i<m.orderItemlist.Count;i=i+1)
            {
                orderItemlist_equal = orderItemlist_equal && (m.orderItemlist[i].Equals( orderItemlist[i]));
            }
            return m != null && m.customer.Equals (customer) && orderItemlist_equal && m.totalprice == totalprice;
        }
        public override string ToString()
        {
            Console.WriteLine("客户:"+customer);
            Console.WriteLine("订单号:"+id);
            foreach (OrderItem a in orderItemlist)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
            return "该订单总计:" + totalprice;
        }

    }
}
