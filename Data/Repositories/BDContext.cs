using System.Data.SqlClient;
using System;
namespace ProjectInter.Data.Repositories
{
    public abstract class BDContext
    {
        protected SqlConnection connection;

        // Construtor
        public BDContext()
        {
            var strConnection = "Data Source = localhost; Integrated Security = True; Initial Catalog = point_summer_foods_dev";
            connection = new SqlConnection(strConnection);
            connection.Open();
            Console.WriteLine("Conexão Aberta");
        }

        public void Dispose()
        {
            connection.Close();
            Console.WriteLine("Conexão fechada");
        }
    }
}

