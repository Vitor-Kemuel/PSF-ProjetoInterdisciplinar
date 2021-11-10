using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;

namespace ProjectInter.Data.Repositories
{
    public class EmployessRepository : BDContext, IEmployeesRepository
    {
        public void Create(Employees employee)
        {
           try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "cadFuncionario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", employees.Name);
                cmd.Parameters.AddWithValue("@celular", employees.Cellphone);
                cmd.Parameters.AddWithValue("@email", employees.Email);
                cmd.Parameters.AddWithValue("@senha", employees.Password);
                cmd.Parameters.AddWithValue("@salario", employees.Salario);
                cmd.Parameters.AddWithValue("@cargo", employees.Cargo);
                cmd.ExecuteNonQuery();
           }catch(Exception ex){
                Console.WriteLine("Erro: " + ex.Message);
           }finally{
               Dispose();
           }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employees GetEmployee(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employees> GetListEmployees()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Employees employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
