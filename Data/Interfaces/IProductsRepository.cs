using System.Collections.Generic;
using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IProductsRepository
    {
        void Create(Products products);

        Products GetSingleProducts(int IdProduct);

        List<Products> GetAllProducts();

        void UpdateProduct(Products products, int IdProduct);

        void Delete(int IdProduct);

        void SearchProdutos(string name);
    }
}
