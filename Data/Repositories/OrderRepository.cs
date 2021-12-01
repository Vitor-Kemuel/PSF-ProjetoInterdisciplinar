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


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                // cmd.CommandText = "V_LISTA_PEDIDOS";
                // cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "SELECT * from V_LISTA_PEDIDOS";

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
                    orders.Add(order);
                }

                foreach (var item in orders)
                {
                    List<ProductsOrders> listProductsOrders = new List<ProductsOrders>();

                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = connection;

                    cmdItem.CommandText = "SELECT * FROM V_PRODUTOS_PEDIDOS where id_pedidos = @id_pedidos";
                    cmdItem.Parameters.AddWithValue("@id_pedidos", item.IdOrder);

                    SqlDataReader reader2 = cmdItem.ExecuteReader();

                    while(reader2.Read()){
                        ProductsOrders p = new ProductsOrders(){
                            IdPedido = (int) reader2["id_pedidos"],
                            Quantify = (int) reader2["quantidade"],
                            Products = new Products(){
                                IdProducts = (int) reader2["id_produtos"]
                            }
                        };
                        listProductsOrders.Add(p);
                    }
                    item.Itens = listProductsOrders;
                }

                return (orders);
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
