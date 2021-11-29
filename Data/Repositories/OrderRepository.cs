using ProjectInter.Data.Interfaces;
using ProjectInter.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ProjectInter.Data.Repositories
{
    public class OrderRepository : BDContext, IdOrderRepository
    {
        public void Create(Order order)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "regVenda" + "SELECT @@IDENTITY";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", order.Customer.IdPerson);
                cmd.Parameters.AddWithValue("@id_funcionario", order.Employees.IdPerson);
                cmd.Parameters.AddWithValue("@observacoes", order.Observations);
                cmd.Parameters.AddWithValue("@situacao", order.Situation);
                cmd.Parameters.AddWithValue("@data_venda", order.DateToSell);
                cmd.Parameters.AddWithValue("@pedido_lido", order.OrderRead);
                cmd.Parameters.AddWithValue("@pedido_produzido", order.OrderAccepted);
                cmd.Parameters.AddWithValue("@pedido_entregue", order.OrderDelivery);

                var idPedido = Convert.ToInt16(cmd.ExecuteScalar());


                foreach( var item in order.Itens){

                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.CommandText = "PRODUTO_PEDIDOS";
                    cmdItem.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_pedido", item.IdPedido);
                    cmd.Parameters.AddWithValue("@id_produto", item.IdProduto);
                    cmd.Parameters.AddWithValue("@quantidade", item.Quantify);
                    cmd.Parameters.AddWithValue("@valor_total", item.ValueTotal); /* Naturalmente é calculado e não cadastrado */


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
                List<Order> order = new List<Order>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT id_produtos, id_pedidos, quantidade FROM v_itensPed";

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    Order orders = new Order(){
                        IdProducts = (int) reader["id_produtos"],
                        IdOrder = (int) reader["id_pedidos"],
                        Quantify = (int)reader["quantidade"],
                        }
                    };
                    order.Add(orders);
                }
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            };
        }

        public void GetSingleOrder(int idOrder)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_produtos, id_pedidos, quantidade FROM v_itensPed WHERE id_pedidos= @id";
                cmd.Parameters.AddWithValue("@id", IdOrder);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()){
                    Order orders = new Order(){
                        IdProducts = (int) reader["id_produtos"],
                        IdOrder = (int) reader["id_pedidos"],
                        Quantify = (int)reader["quantidade"],
                        }

                    };
                    return orders;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } finally {
                Dispose();
            }
        }
    }
}
