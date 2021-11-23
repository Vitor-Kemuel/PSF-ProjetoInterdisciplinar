using ProjectInter.Data.Interfaces;
using System.Data.SqlClient;
using System;
using ProjectInter.Models;
using System.Data;
using System.Collections.Generic;

namespace ProjectInter.Data.Repositories
{
    public class PurchaseRepository : BDContext, IPurchaseRepository
    {
        public void Create(Purchase purchase)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "cadCompra";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@data_compra", purchase.PurchaseDate);
                // cmd.Parameters.AddWithValue("@quantidade", purchase.Quantify);
                // cmd.Parameters.AddWithValue("@valor_total", purchase.TotalValue);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } finally {
                Dispose();
            }
        }

        public List<Purchase> GetAllPurchases()
        {
            try
            {
                List<Purchase> purchases = new List<Purchase>();

               SqlCommand cmd = new SqlCommand();
               cmd.Connection = connection;

               cmd.CommandText = "SELECT id_produtos, data_compra, quantidade, valor_total FROM v_listaCadCompra";

               SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    Purchase purchase = new Purchase(){
                        IdPurchase = (int) reader["id_produtos"],
                        PurchaseDate = (DateTime)reader["data_compra"],
                        // Quantify = (int)reader["quantidade"],
                        // TotalValue = (double) reader["valor_total"],
                    };
                    purchases.Add(purchase);
                }

                return purchases;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } finally {
                Dispose();
            }
        }

        public Purchase GetSinglePurchase(int IdPurchase)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_produtos, data_compra, quantidade, valor_total FROM v_listaCadCompra WHERE id_produtos= @id";
                cmd.Parameters.AddWithValue("@id", IdPurchase);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()){
                    Purchase purchase = new Purchase(){
                        IdPurchase = (int) reader["id_produtos"],
                        PurchaseDate = (DateTime)reader["data_compra"],
                        // Quantify = (int)reader["quantidade"],
                        // TotalValue = (double) reader["valor_total"],

                    };
                    return purchase;
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
    }
}
