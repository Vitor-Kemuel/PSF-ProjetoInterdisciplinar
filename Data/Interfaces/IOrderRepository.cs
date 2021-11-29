using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IdOrderRepository
    {
        void Create(Order order);

        List<Order> GetAllOrders();

        void IdOrderRepository.GetSingleOrder(int idOrder);
    }
}
