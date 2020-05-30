using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework12.Models;

namespace Homework12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext orderdb;

        public OrdersController(OrderContext context)
        {
            orderdb = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            IQueryable<Order> query = orderdb.Orders;
            foreach (Order x in query)
                x.orderItemList = orderdb.OrderItems.Where(o => o.Id == x.Id).ToList();
            return query;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var query = orderdb.Orders.FirstOrDefault(o => o.Id == id);
            if (query == null)
            {
                return NotFound();
            }
            query.orderItemList = orderdb.OrderItems.Where(o => o.Id == query.Id).ToList();
            return query;

       ;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(string id,  Order order)
        {
            if(id!=order.Id)
            {
                return BadRequest("id cannot be modified");        
            }
            try
            {
                orderdb.Entry(order).State = EntityState.Modified;
                foreach (OrderItem x in order.orderItemList)
                    orderdb.Entry(x).State = EntityState.Modified;
                orderdb.SaveChanges();
            }catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderdb.Orders.Add(order);
                orderdb.SaveChanges();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder(string id)
        {
            try
            {
                var order = orderdb.Orders.Include("orderItemList").FirstOrDefault(x => x.Id == id);
                if (order != null)
                {
                    orderdb.Orders.Remove(order);
                    orderdb.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }

        private bool OrderExists(string id)
        {
            return orderdb.Orders.Any(e => e.Id == id);
        }
    }
}