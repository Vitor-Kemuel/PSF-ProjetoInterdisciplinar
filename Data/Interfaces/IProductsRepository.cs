using System.Collections.Generic;
using ProjectInter.Models;
namespace ProjectInter.Data.Interfaces
{
    public interface IProductsRepository
    {
        void Create(Products products);

        Products GetSingleProducts(int IdProduct);

        List<Products> GetAllProducts();

        void UpdateProduct(int IdProduct, string name, double price);

        void Delete(int IdProduct);

        void SearchProdutos(string name);
    }
}
