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
                cmd.Parameters.AddWithValue("@situacao", Constants.ATIVO);
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
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE PESSOAS SET SITUACAO = 1 WHERE id_pessoa = @id";
                cmd.Parameters.AddWithValue("@id",id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            } finally{
                Dispose();
            }
        }

        public Employees GetSingleEmployee(int id)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_pessoas, salario, cargo FROM v_listaFuncionario WHERE id_pessoas = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()){
                    Employees employee = new Employees(){
                        IdPerson = (int) reader["id_pessoas"],
                            Name = (string) reader["nome"],
                            Cellphone = (string)reader["celular"],
                            Email = (string) reader["email"],
                            Password = (string) reader["senha"],
                            Wage = (decimal)reader["salario"],
                            Responsibility = (string)reader["cargo"],
                    };
                    return employee;
                }

                return null;
            } catch (Exception ex) {
                throw new Exception("Erro: "+ ex.Message);
            } finally {
                Dispose();
            }

        }

        public List<Employees> GetListEmployees()
        {
            try
            {
                List<Employees> employees = new List<Employees>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                // Heitor tem que corrigir, trazer todos os dados de pessoa, e não somente id_pessoas
                cmd.CommandText = "SELECT id_pessoas, nome, celular, email, senha, salario, cargo FROM v_listaFuncionario";

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    Employees employee = new Employees(){
                        IdPerson = (int) reader["id_pessoas"],
                            Name = (string) reader["nome"],
                            Cellphone = (string)reader["celular"],
                            Email = (string) reader["email"],
                            Password = (string) reader["senha"],
                            Wage = (decimal)reader["salario"],
                            Responsibility = (string)reader["cargo"],
                    };

                    employees.Add(employee);
                }

                return employees;

            } catch (Exception ex) {
                 throw new Exception(ex.Message);
            } finally {
                Dispose();
            }
        }

        public Employees Login(Employees employees){
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = " SELECT * FROM v_listaFuncionario WHERE email = @email AND senha = @senha";

                cmd.Parameters.AddWithValue("@email", employees.Email);
                cmd.Parameters.AddWithValue("@senha", employees.Password);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()){
                    Employees ObjEmployee  = new Employees(){
                        IdPerson = (int)            reader["id_pessoas"],
                        Name     = (string)         reader["nome"],
                        Cellphone = (string)        reader["celular"],
                        Email = (string)            reader["email"],
                        Password = (string)         reader["senha"],
                        Wage = (decimal)            reader["salario"],
                        Responsibility = (string)   reader["cargo"],
                    };

                 return ObjEmployee;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void Update(int id, Employees employee)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "ProcedurePendente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", employee.Name);
                cmd.Parameters.AddWithValue("@celular", employee.Cellphone);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@senha", employee.Password);
                cmd.Parameters.AddWithValue("@cargo", employee.Responsibility);
                cmd.Parameters.AddWithValue("@salario", employee.Wage);

                cmd.ExecuteNonQuery();

            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public void SearchEmployee(string name)
        {
            throw new NotImplementedException();
        }
    }
}
