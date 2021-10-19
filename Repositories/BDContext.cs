using System.Data.SqlClient;

namespace ProjectInter.Repositories
{
    public abstract class BDContext
    {
        protected SqlConnection connection;

        // Construtor
        public BDContext()
        {
            var strConnection = "Data Source = localhost; Integrated Security = True; Initial Catalog = PointSummerFoods";
            connection = new SqlConnection(strConnection);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}

