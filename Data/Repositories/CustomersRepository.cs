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
        public void Create(Customers customers)
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
                cmd.Parameters.AddWithValue("@situacao", Constants.ATIVO );
                cmd.Parameters.AddWithValue("@cpf", customers.Cpf);
                cmd.Parameters.AddWithValue("@endereco", customers.Address.NameAddress);
                cmd.Parameters.AddWithValue("@complemento", (object) customers.Address.ComplementAddress?? DBNull.Value);
                cmd.Parameters.AddWithValue("@numero_endereco", customers.Address.NumberAddress);
                cmd.Parameters.AddWithValue("@bairro", customers.Address.District);
                cmd.Parameters.AddWithValue("@cep", customers.Address.ZipCodeAddress);

                cmd.ExecuteNonQuery();

            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            } finally {
                Dispose();
            }
        }
        public void Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pessoas", id);
                cmd.Parameters.AddWithValue("@situacao", Constants.DESATIVADO);

                cmd.ExecuteNonQuery();

            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            } finally {
                Dispose();
            }
        }

        public Customers GetSingleCustomer(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_pessoas, nome, celular, email, senha, cpf, endereco, complemento, numero, bairro, cep FROM v_listaClientes WHERE id_pessoas = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()){
                    Customers customer = new Customers(){
                        IdPerson = (int) reader["id_pessoas"],
                        Name = (string)reader["nome"],
                        Cellphone = (string)reader["celular"],
                        Email = (string) reader["email"],
                        Password = (string) reader["senha"],
                        Cpf = (string) reader["cpf"],
                        Address = new Address(){
                            NameAddress = (string) reader["endereco"],
                            ComplementAddress = (string) (reader["complemento"] == DBNull.Value ? "" : reader["complemento"]),
                            NumberAddress = (string) reader["numero"],
                            District = (string) reader["bairro"],
                            ZipCodeAddress = (string) reader["cep"],
                        }
                    };
                    return customer;
                }

                return null;
            } catch (Exception ex) {
                throw new Exception("Erro: "+ ex.Message);
            } finally {
                Dispose();
            }
        }

        public List<Customers> GetAllCustomers()
        {
            try
            {
                List<Customers> customers = new List<Customers>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_pessoas, nome, celular, email, senha, cpf, endereco, complemento, numero, bairro, cep FROM v_listaClientes where situacao = @situacao";

                cmd.Parameters.AddWithValue("@situacao", Constants.ATIVO);
               
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    Customers customer = new Customers(){
                        IdPerson = (int) reader["id_pessoas"],
                        Name = (string)reader["nome"],
                        Cellphone = (string)reader["celular"],
                        Email = (string) reader["email"],
                        Password = (string) reader["senha"],
                        Cpf = (string) reader["cpf"],
                        Address = new Address(){
                            NameAddress = (string) reader["endereco"],
                            ComplementAddress = (string) (reader["complemento"] == DBNull.Value ? "" : reader["complemento"]),
                            NumberAddress = (string) reader["numero"],
                            District = (string) reader["bairro"],
                            ZipCodeAddress = (string) reader["cep"],
                         }
                    };

                    customers.Add(customer);
                }

                return customers;

            } catch (Exception ex) {
                 throw new Exception(ex.Message);
            } finally {
                Dispose();
            }
        }

        public void Update(int id, Customers customers)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "altClientes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pessoas", id);
                cmd.Parameters.AddWithValue("@nome", customers.Name);
                cmd.Parameters.AddWithValue("@celular", customers.Cellphone);
                cmd.Parameters.AddWithValue("@email", customers.Email);
                cmd.Parameters.AddWithValue("@senha", customers.Password);
                cmd.Parameters.AddWithValue("@situacao", Constants.ATIVO );
                cmd.Parameters.AddWithValue("@cpf", customers.Cpf);
                cmd.Parameters.AddWithValue("@endereco", customers.Address.NameAddress);
                cmd.Parameters.AddWithValue("@complemento", (object) customers.Address.ComplementAddress?? DBNull.Value);
                cmd.Parameters.AddWithValue("@numero_endereco", customers.Address.NumberAddress);
                cmd.Parameters.AddWithValue("@bairro", customers.Address.District);
                cmd.Parameters.AddWithValue("@cep", customers.Address.ZipCodeAddress);

                cmd.ExecuteNonQuery();

            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                Dispose();
            }
        }

        public List<Customers> SearchCustomer(string name)
        {
            try
            {
                List<Customers> customers = new List<Customers>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_pessoas, nome, celular, email, senha, cpf, endereco, complemento, numero, bairro, cep FROM v_listaClientes WHERE nome LIKE %@name%";

                cmd.Parameters.AddWithValue("@name", name);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    Customers customer = new Customers(){
                        IdPerson = (int) reader["id_pessoas"],
                        Name = (string)reader["nome"],
                        Cellphone = (string)reader["celular"],
                        Email = (string) reader["email"],
                        Password = (string) reader["senha"],
                        Cpf = (string) reader["cpf"],
                        Address = new Address(){
                            NameAddress = (string) reader["endereco"],
                            ComplementAddress = (string) (reader["complemento"] == DBNull.Value ? "" : reader["complemento"]),
                            NumberAddress = (string) reader["numero"],
                            District = (string) reader["bairro"],
                            ZipCodeAddress = (string) reader["cep"],
                        }
                    };
                    customers.Add(customer);
                }

                return customers;
            } catch (Exception ex) {
                throw new Exception("Erro: "+ ex.Message);
            } finally {
                Dispose();
            }
        }
    }
}
