using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<Order> orders = new();

        public DemoDataAccess()
        {
            orders.Add(new Order { IDOrder = 1, OrderName = "Purchase Harry Potter" });
            orders.Add(new Order { IDOrder = 2, OrderName = "Purchase Atack of Titan" });
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public Order InsertOrder(string orderName)
        {
            Order o = new() { OrderName = orderName };
            o.IDOrder = orders.Max(x => x.IDOrder) + 1;
            orders.Add(o);
            return o;
        }
    }
}
