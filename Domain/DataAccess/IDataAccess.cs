using Domain.Models;

namespace Domain.DataAccess
{
    public interface IDataAccess
    {
        List<Order> GetOrders();
        Order InsertOrder(string orderName);
    }
}