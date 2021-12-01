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

            try
            {
                 List<Order> orders = new List<Order>();
            List<ProductsOrders> listProductsOrders = new List<ProductsOrders>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "V_LISTA_PEDIDOS";
            cmd.CommandType = CommandType.TableDirect;

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                Order order = new Order(){
                    IdOrder = (int) reader["id_pedidos"],
                    DateToSell = (DateTime) reader["data_venda"],
                    Situation = (int) reader["situacao"],
                    OrderAccepted = (DateTime) reader["pedido_produzindo"],
                    OrderRead = (DateTime) reader["pedido_lido"],
                    OrderDelivery = (DateTime) reader["pedido_entregue"],
                    Customer = new Customers(){
                        IdPerson = (int) reader["id_clientes"],
                    }
                };

                foreach (var item in order.Itens)
                {
                   SqlCommand cmdItem = new SqlCommand();

                   cmdItem.CommandText = "V_PRODUTOS_PEDIDOS where id_pedidos = @id_pedidos";
                   cmd.Parameters.AddWithValue("@id_pedidos", order.IdOrder);

                   item.IdPedido = (int) reader["id_pedidos"];
                   item.Quantify = (int) reader["quantidade"];
                   item.Products.IdProducts = (int) reader["id_produtos"];

                   listProductsOrders.Add(item);
                }

                order.Itens = listProductsOrders;
                orders.Add(order);
            }

            return orders;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            finally{
                Dispose();
            }
        }

        public Order GetSingleOrder(int idOrder)
        {
            throw new NotImplementedException();
        }

    }
}
