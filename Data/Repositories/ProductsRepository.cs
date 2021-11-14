using ProjectInter.Data.Interfaces;
using System.Data.SqlClient;
using System;
using ProjectInter.Models;
using System.Data;

namespace ProjectInter.Data.Repositories
{
    public class ProductsRepository : BDContext, IProductsRepository
    {
        public void Create(Products products)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "cadProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_produto", products.CodeProducts);
                cmd.Parameters.AddWithValue("@nome", products.Name);
                cmd.Parameters.AddWithValue("@estoque", products.Inventory);
                //cmd.Parameters.AddWithValue("@preco", products.Price);
                cmd.Parameters.AddWithValue("@tipoproduto", products.TypeProduct);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void GetAllProducts()
        {
            try
            {
                 throw new System.NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void GetProducts(int IdProduct)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduct(Products products, int IdProduct)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "ProcedurePendente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_produto", products.CodeProducts);
                cmd.Parameters.AddWithValue("@nome", products.Name);
                cmd.Parameters.AddWithValue("@estoque", products.Inventory);
                //cmd.Parameters.AddWithValue("@preco", products.Price);
                cmd.Parameters.AddWithValue("@tipoproduto", products.TypeProduct);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void Delete(int IdProduct)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE PRODUTOS set situacao = 1 where id_produtos = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", IdProduct);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void UpdateProdutc(Products products, int IdProduct)
        {
            throw new NotImplementedException();
        }
    }
}
