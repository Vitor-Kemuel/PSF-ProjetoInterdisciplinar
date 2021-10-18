using System.Data.SqlClient;



namespace TodoList.Repositories
{
    public abstract class BDContext
    {
        // Atributo
        protected SqlConnection connection;

        // Construtor
        public BDContext()
        {
            var strConnection = "Data Source = localhost; Integrated Security = True; Initial Catalog = BDTodo";
            connection = new SqlConnection(strConnection);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}

