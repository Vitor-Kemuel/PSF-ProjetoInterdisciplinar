using System;
using System.Collections.Generic;
using ProjectInter.Models;
using System.Data.SqlClient;

namespace ProjectInter.Repositories
{
    public class PersonsDatabaseRepository : BDContext
    {
        public void Create(Persons model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public void Update(int id, Persons model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public Persons Read(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
        }
    }
}
