using ProjectInter.Data.Interfaces;
using ProjectInter.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ProjectInter.Data.Repositories
{
    public class OrderRepository : BDContext, IOrderRepository
    {
        public void Create(Order order)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "regPedidos";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", order.Customer.IdPerson);
                cmd.Parameters.AddWithValue("@situacao", order.Situation);
                cmd.Parameters.AddWithValue("@data_venda", order.DateToSell);
                cmd.Parameters.AddWithValue("@pedido_lido", order.OrderRead);
                cmd.Parameters.AddWithValue("@pedido_produzindo", order.OrderAccepted);
                cmd.Parameters.AddWithValue("@pedido_entregue", order.OrderDelivery);

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT @@IDENTITY";
                cmd.CommandType = CommandType.Text;

                var idPedido = Convert.ToInt16(cmd.ExecuteScalar());

                foreach( var item in order.Itens){


                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = connection;

                    cmdItem.CommandText = "itensPed";
                    cmdItem.CommandType = CommandType.StoredProcedure;

                    cmdItem.Parameters.AddWithValue("@id_pedidos", idPedido);
                    cmdItem.Parameters.AddWithValue("@id_produtos", item.Produtos.IdProducts);
                    cmdItem.Parameters.AddWithValue("@quantidade", item.Quantify);
                    // cmd.Parameters.AddWithValue("@valor_total", item.ValueTotal); /* Naturalmente é calculado e não cadastrado */


                    cmdItem.ExecuteNonQuery();
                }

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            } finally {
                Dispose();
            }

        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetSingleOrder(int idOrder)
        {
            throw new NotImplementedException();
        }

        // public List<Order> GetAllOrders()
        // {
        //     try
        //     {
        //         List<Order> order = new List<Order>();

        //         SqlCommand cmd = new SqlCommand();
        //         cmd.Connection = connection;
        //         cmd.CommandText = "SELECT id_produtos, id_pedidos, quantidade FROM v_itensPed";

        //         SqlDataReader reader = cmd.ExecuteReader();

        //         while(reader.Read()){
        //             Order orders = new Order(){
        //                 IdProducts = (int) reader["id_produtos"],
        //                 IdOrder = (int) reader["id_pedidos"],
        //                 Quantify = (int)reader["quantidade"],
        //                 }
        //             };
        //             order.Add(orders);
        //         }
        //         return order;

        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }finally{
        //         Dispose();
        //     };
        // }

        // public void GetSingleOrder(int idOrder)
        // {
        //     try
        //     {
        //         SqlCommand cmd = new SqlCommand();
        //         cmd.Connection = connection;

        //         cmd.CommandText = "SELECT id_produtos, id_pedidos, quantidade FROM v_itensPed WHERE id_pedidos= @id";
        //         cmd.Parameters.AddWithValue("@id", IdOrder);

        //         SqlDataReader reader = cmd.ExecuteReader();

        //         if(reader.Read()){
        //             Order orders = new Order(){
        //                 IdProducts = (int) reader["id_produtos"],
        //                 IdOrder = (int) reader["id_pedidos"],
        //                 Quantify = (int)reader["quantidade"],
        //                 }

        //             };
        //             return orders;
        //         }

        //         return null;
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     } finally {
        //         Dispose();
        //     }
        // }
    }
}
