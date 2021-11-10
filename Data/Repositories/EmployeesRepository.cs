using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System;

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
                
                cmd.Parameters.AddWithValue("@nome", employee.Name);
                cmd.Parameters.AddWithValue("@celular", employee.Cellphone);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@senha", employee.Password);
                cmd.Parameters.AddWithValue("@salario", employee.Wage);
                cmd.Parameters.AddWithValue("@cargo", employee.Responsibility);
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
