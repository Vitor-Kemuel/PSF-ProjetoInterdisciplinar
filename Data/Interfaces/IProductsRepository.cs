using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IProductsRepository
    {
        void Create(Products products);

        void GetSingleProducts(int IdProduct);

        void GetAllProducts();

        void UpdateProduct(Products products, int IdProduct);

        void Delete(int IdProduct);
    }
}
