using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IdOrderRepository
    {
        void Create(Order order, ProductsOrders itens, int idCliente, int idFuncionario, int idProduto );

        void GetAllOrders();

        void GetOrderForSilgeCustomer(int idCustomer);
    }
}
