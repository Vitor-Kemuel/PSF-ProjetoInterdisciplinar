using System.Collections.Generic;
using ProjectInter.Models;

namespace ProjectInter.Repositories
{
    public class CustomersDataBaseRepository : BDContext, ICustomersRepository
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

        public List<Customers> GetListCustomers()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Customers customers)
        {
            throw new System.NotImplementedException();
        }
    }
}