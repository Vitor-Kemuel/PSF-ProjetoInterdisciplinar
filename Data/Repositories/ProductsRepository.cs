using ProjectInter.Data.Interfaces;
using System.Data.SqlClient;
using System;
using ProjectInter.Models;
using System.Data;

namespace ProjectInter.Data.Repositories
{
    public class ProductsRepository : BDContext, IProductsRepository
    {
        //Um produto pode ter vários tipos
        public void Create(Products products)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "cadProduto";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@imagem", products.Image);
                cmd.Parameters.AddWithValue("@nome", products.Name);
                cmd.Parameters.AddWithValue("@estoque", products.Inventory);
                cmd.Parameters.AddWithValue("@situacao", products.Status);
                cmd.Parameters.AddWithValue("@preco", products.TypeProduct.Price);
                cmd.Parameters.AddWithValue("@tamanho", products.TypeProduct.ProductSize);

                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            } finally {
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

        public void GetSingleProducts(int IdProduct)
        {
            throw new System.NotImplementedException();
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

        //Um produto pode ter vários tipos e está faltando comparar com o idProduct
        public void UpdateProduct(Products products, int IdProduct)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "altProduto where id_produtos = @id";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", IdProduct);

                cmd.Parameters.AddWithValue("@nome", products.Name);
                cmd.Parameters.AddWithValue("@estoque", products.Inventory);
                cmd.Parameters.AddWithValue("@situacao", products.Status);
                cmd.Parameters.AddWithValue("@preco", products.TypeProduct.Price);
                cmd.Parameters.AddWithValue("@tipoproduto", products.TypeProduct.TypeProduct);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }
    }
}
