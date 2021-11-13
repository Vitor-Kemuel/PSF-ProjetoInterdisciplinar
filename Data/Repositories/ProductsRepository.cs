using ProjectInter.Data.Interfaces;

namespace ProjectInter.Data.Repositories
{
    public class ProductsRepository : BDContext, IProductsRepository
    {
        public void Create()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "cadProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_produto", product.CodeProducts);
                cmd.Parameters.AddWithValue("@nome", product.Name);
                cmd.Parameters.AddWithValue("@estoque", product.Inventory);
                cmd.Parameters.AddWithValue("@preco", product.Price);
                cmd.Parameters.AddWithValue("@tipoproduto", product.TypeProduct);

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

        public void UpdateProduct(int IdProduct)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "ProcedurePendente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_produto", product.CodeProducts);
                cmd.Parameters.AddWithValue("@nome", product.Name);
                cmd.Parameters.AddWithValue("@estoque", product.Inventory);
                cmd.Parameters.AddWithValue("@preco", product.Price);
                cmd.Parameters.AddWithValue("@tipoproduto", product.TypeProduct);

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
                cmd.Parameters.AddWithValue("@id", id);

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
