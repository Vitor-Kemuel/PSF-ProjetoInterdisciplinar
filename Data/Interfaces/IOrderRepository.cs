using System.Collections.Generic;
using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IdOrderRepository
    {
        void Create(Order order);

        List<Order> GetAllOrders();

        Order GetSingleOrder(int idOrder);
    }
}
