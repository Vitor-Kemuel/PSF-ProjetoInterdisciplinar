using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;

namespace ProjectInter.Data.Repositories
{
    public class CustomersRepository : BDContext, ICustomersRepository
    {
        public void Create(Customers customers)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void Update(int id, Customers customers)
        {
            throw new System.NotImplementedException();
        }
    }
}