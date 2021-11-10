using System;
using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace ProjectInter.Data.Repositories
{
    public class CustomersRepository : BDContext, ICustomersRepository
    {
        public void Create(Customers customers, Address address)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "cadCliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nome", customers.Name);
                cmd.Parameters.AddWithValue("@celular", customers.Cellphone);
                cmd.Parameters.AddWithValue("@email", customers.Email);
                cmd.Parameters.AddWithValue("@senha", customers.Password);
                cmd.Parameters.AddWithValue("@cpf", customers.Cpf);
                cmd.Parameters.AddWithValue("@endereco", address.NameAddress);
                cmd.Parameters.AddWithValue("@complemento", address.ComplementAddress);
                cmd.Parameters.AddWithValue("@numero_endereco", address.NumberAddress);
                cmd.Parameters.AddWithValue("@bairro", address.District);
                cmd.Parameters.AddWithValue("@cep", address.ZipCodeAddress);
                cmd.ExecuteNonQuery();


            } catch(Exception ex){
                Console.WriteLine("Erro: " + ex.Message);
            } finally{
                Dispose();
            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Customers GetCustomer(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Customers> GetAllCustomers()
        {
            try
            {
                List<Customers> customers = new List<Customers>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "v_listaClientes";
                cmd.CommandType = CommandType.TableDirect;

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){

                    Address address = new Address(){
                        NameAddress = reader.GetString(5),
                        ComplementAddress = reader.GetString(6),
                        NumberAddress = reader.GetString(7),
                        District = reader.GetString(8),
                        ZipCodeAddress = reader.GetString(9),
                    };

                    Customers customer = new Customers(){
                         Name = reader.GetString(0),
                         Cellphone = reader.GetString(1),
                         Email = reader.GetString(2),
                         Password = reader.GetString(3),
                         Cpf = reader.GetString(4),
                         Address = address
                    };
                     
                    customers.Add(customer);
                    return customers;
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

        public void Update(int id, Customers customers)
        {
            throw new System.NotImplementedException();
        }
    }
}
