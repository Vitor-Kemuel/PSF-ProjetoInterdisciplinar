using System;
using System.Collections.Generic;
using TodoList.Models;
using System.Data.SqlClient;



namespace TodoList.Repositories
{
    public class PersonsDatabaseRepository : BDContext, IPersonsRepository
    {
        public void Create(Persons model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public void Delete(int id){
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public void Update(int id, Tarefa model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public Persons Read(int id){
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }
    }
}
