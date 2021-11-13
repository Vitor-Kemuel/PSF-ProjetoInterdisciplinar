namespace ProjectInter.Data.Interfaces
{
    public interface IdOrderRepository
    {
        void Create(int idCustomers, int idProducts);

        void GetAllOrders();

        void GetOrderForSilgeCustomer(int idCustomer);
    }
}
