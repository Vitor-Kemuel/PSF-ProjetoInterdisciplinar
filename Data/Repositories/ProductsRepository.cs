using ProjectInter.Data.Interfaces;
using System.Data.SqlClient;
using System;
using ProjectInter.Models;
using System.Data;
using System.Collections.Generic;

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
                cmd.Parameters.AddWithValue("@estoque", Constants.INITIAL_INVENTORY);
                cmd.Parameters.AddWithValue("@situacao", Constants.ATIVO);
                cmd.Parameters.AddWithValue("@preco", products.TypeProduct.Price);
                cmd.Parameters.AddWithValue("@tipo_medida", products.TypeProduct.TypeUnit);
                cmd.Parameters.AddWithValue("@tipo_produto", products.TypeProduct.TypeProduct);

                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            } finally {
                Dispose();
            }
        }

        public List<Products> GetAllProducts()
        {

            try
            {
                List<Products> products = new List<Products>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT id_produtos, imagem, nome, estoque, preco, tipo_medida, tipo_produto FROM v_listaProduto WHERE situacao = 1";

                SqlDataReader reader = cmd.ExecuteReader();

                /*
                    atribuição de id comentada, pois, não se tem o retorno dela pelo banco de dados
                    atribuição de quantidade comentada, pois, está com erro ao alterar tipo de dado
                    atribuição de preço comentada, pois, está com erro ao alterar tipo de dado
                */

                while(reader.Read()){
                    Products product = new Products(){
                        IdProducts = (int) reader["id_produtos"],
                        Image = (string)reader["imagem"],
                        Name = (string)reader["nome"],
                        Inventory = Math.Round(Convert.ToDouble((reader["estoque"])), 2),
                        TypeProduct = new TypeProducts(){
                            Price = Math.Round(Convert.ToDouble(reader["preco"]), 2),
                            TypeUnit = (int) reader["tipo_medida"],
                            TypeProduct = (int) reader["tipo_produto"],
                        }
                    };
                    products.Add(product);
                }

                return products;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public Products GetSingleProducts(int IdProduct)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_produtos, imagem, nome, estoque, preco, tipo_medida, tipo_produto FROM v_listaProduto WHERE id_produtos= @id";
                cmd.Parameters.AddWithValue("@id", IdProduct);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()){
                    Products product = new Products(){
                        IdProducts = (int) reader["id_produtos"],
                        Image = (string)reader["imagem"],
                        Name = (string)reader["nome"],
                        Inventory = (float) reader["estoque"],
                        TypeProduct = new TypeProducts(){
                            Price = (double) reader["preco"],
                            TypeUnit = (int) reader["tipo_medida"],
                            TypeProduct = (int) reader["tipo_produto"],
                        }
                    };
                    return product;
                }

                return null;

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
