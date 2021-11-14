using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IProductsRepository
    {
        void Create(Products products);

        void GetProducts(int IdProduct);

        void GetAllProducts();

        void UpdateProdutc(Products products, int IdProduct);

        void Delete(int IdProduct);
    }
}
