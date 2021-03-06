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

                cmd.Parameters.AddWithValue("@imagem", (object) products.Image?? DBNull.Value);
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

                while(reader.Read()){
                    Products product = new Products(){
                        IdProducts = (int) reader["id_produtos"],
                        Image = (string) (reader["imagem"] == DBNull.Value ? " " : reader["imagem"]),
                        Name = (string)reader["nome"],
                        Inventory = Convert.ToDouble((reader["estoque"])),
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
                        Image = (string) (reader["imagem"] == DBNull.Value ? null : reader["imagem"] ) ,
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

        public void Delete(int idProduct)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delProduto";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id_produto", idProduct);
                cmd.Parameters.AddWithValue("@situacao", Constants.DESATIVADO);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void UpdateProduct(int idProduct, string name, double price)
        {
            try
            {
                Products products = new Products();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "altProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_produtos", idProduct);

                cmd.Parameters.AddWithValue("@nome", name);
                cmd.Parameters.AddWithValue("@preco", price);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void SearchProdutos(string name)
        {
            throw new NotImplementedException();
        }
    }
}
