using ProjectInter.Data.Interfaces;

namespace ProjectInter.Data.Repositories
{
    public class OrderRepository : BDContext, IdOrderRepository
    {
        public void Create(int idCustomers, int idProducts)
        {
            throw new System.NotImplementedException();
        }

        public void GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public void GetOrderForSilgeCustomer(int idCustomer)
        {
            throw new System.NotImplementedException();
        }
    }
}