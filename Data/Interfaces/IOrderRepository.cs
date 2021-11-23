using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IdOrderRepository
    {
        void Create(Order order);

        void GetAllOrders();

        void GetSingleOrder(int idOrder);
    }
}
