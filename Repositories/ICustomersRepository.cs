using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Repositories
{
    public interface ICustomersRepository
    {
        void Create(Customers customers);
        List<Customers> GetListCustomers();
        Customers GetCustomer(int id);
        void Update(int id, Customers customers);
        void Delete(int id);
    }
}