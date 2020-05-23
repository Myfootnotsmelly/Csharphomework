using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Data.Entity;

namespace Homework11
{
    //订单服务类
    public class OrderService
    {
        //public List<Order> orderList=new List<Order>();
       // public List<Order> OrderList { get { return orderList; } }
        public OrderService() {}
        public static List<Order> GetAllOrders()
        {
            using (var db = new OrderContext())
            {
                return AllOrders(db).ToList();
            }
        }
        private static IQueryable<Order> AllOrders(OrderContext db)
        {
            return db.Orders.Include(o => o.orderItemList.Select(i => i.Goods))
                      .Include("Customer");

        }

        public static void addOrder(Order toAdd)           //添加订单
        {
            try
            {
                using (var db = new OrderContext())
                {
                    db.Orders.Add(toAdd);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("已存在相同订单！");
            }
        }
       /* public void deleteOrder(int id)             //按订单号删除订单
        {
            if (orderList[orderList.FindIndex(x=>x.OrderId==id)] != null)
                orderList.Remove(orderList.Find(x => x.OrderId == id));
            else
                throw new Exception("该订单不存在！");
        }*/
        public static void deleteOrder(int id)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.Include("orderItemList").Where(o => o.OrderId == id).FirstOrDefault();
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
            catch 
            {
                throw new ApplicationException("删除订单错误!");
            }
        }
       /* public void modifyOrder(Order toModify,int id)  //修改订单
        {
            if (orderList[orderList.FindIndex(x => x.OrderId == id)] != null)
                if (!orderList[orderList.FindIndex(x => x.OrderId == id)].Equals(toModify))
                {
                    int index = orderList.FindIndex(x => x.OrderId == id);
                    deleteOrder(id);
                    orderList.Insert(index, toModify);
                }
                else
                    throw new Exception("已存在相同订单！");
        }*/

        public static void modifyOrder(Order newOrder)
        {
            RemoveItems(newOrder.OrderId);
            using (var db = new OrderContext())
            {
                db.Entry(newOrder).State = EntityState.Modified;
                db.OrderItems.AddRange(newOrder.orderItemList);
                db.SaveChanges();
            }
        }
        private static void RemoveItems(int orderId)
        {
            using (var db = new OrderContext())
            {
                var oldItems = db.OrderItems.Where(item => item.OrderId == orderId);
                db.OrderItems.RemoveRange(oldItems);
                db.SaveChanges();
            }
        }
        /*public Order inquiryOrder(int id)                      //按订单号查询
        {
            var query = from s in orderList
                        where s.OrderId == id
                        orderby s.Totalprice descending
                        select s;
            return query.FirstOrDefault();
        }*/
        /*public List<Order> inquiryOrder(string cname)          //按客户名查询
        {
            var query = from s in orderList
                        where s.Cname == cname
                        orderby s.Totalprice descending
                        select s;
            return query.ToList();
        }*/
        /*public List<Order> inquiryOrder(goodstype goodstype )      //按商品名称查询
        {
            var query = orderList.Where(x => x.Items.Exists(y => y.GoodsType == goodstype))
                                 .OrderByDescending(x => x.Totalprice);                 
            return query.ToList();
        }*/
        public Order inquiryOrder(int id)                      //按订单号查询
        {
            using (var db = new OrderContext())
            {
                var query = db.Orders.Where(o => o.OrderId == id);
                return query.FirstOrDefault();

            }
        }
        public List<Order> inquiryOrder(string cname)          //按客户名查询
       {
            using (var db = new OrderContext())
            {
                var query = db.Orders.Where(o => o.Cname == cname);
                return query.ToList();
            }
       }

        public static List<Order> inquiryOrder(goodstype goodstype)
        {
            using (var db = new OrderContext())
            {
                var query = db.Orders
                  .Where(o => o.orderItemList.Exists(y => y.GoodsType == goodstype));
                return query.ToList();
            }
        }



        /*public void sortOrder()                               //按订单号排序
        {
            orderList.Sort((o1, o2) => o1.OrderId - o2.OrderId);
        }*/
        public void Export(string filename)                                  //序列化
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (var db = new OrderContext())
                {
                    xmlSerializer.Serialize(fs, db.Orders);
                }
            }

         }
        public void Import(string fileName)                   //反序列化
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream($"{fileName}", FileMode.Open))
            {
                using (var db = new OrderContext())
                {
                    db.Orders = (DbSet<Order>)xmlSerializer.Deserialize(fs);
                }
            }

        }
    }
}
