using ProjectInter.Data.Interfaces;
using ProjectInter.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProjectInter.Data.Repositories
{
    public class OrderRepository : BDContext, IdOrderRepository
    {
        public void Create(Order order, ProductsOrders itens, int idCliente, int idFuncionario, int idProduto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "regVenda";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", idCliente);
            cmd.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            cmd.Parameters.AddWithValue("@observacoes", order.Observations);
            cmd.Parameters.AddWithValue("@situacao", order.Situation);
            cmd.Parameters.AddWithValue("@data_venda", order.DateToSell);
            cmd.Parameters.AddWithValue("@pedido_lido", order.OrderRead);
            cmd.Parameters.AddWithValue("@pedido_produzido", order.OrderAccepted);
            cmd.Parameters.AddWithValue("@pedido_entregue", order.OrderDelivery);
            cmd.ExecuteNonQuery();
            

            foreach( var item in order.Itens){

                SqlCommand cmdItem = new SqlCommand();
                cmdItem.CommandText = "PRODUTO_PEDIDOS";
                cmdItem.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_produto", item.IdProduto);
                cmd.Parameters.AddWithValue("@quantidade", item.Quantify);
                cmd.Parameters.AddWithValue("@valor_total", item.ValueTotal); /* Naturalmente é calculado e não cadastrado */


                cmdItem.ExecuteNonQuery();
            }

        }

        public void GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public void GetOrderForSilgeCustomer(int idCustomer)
        {
            throw new System.NotImplementedException();
        }
    }
}
