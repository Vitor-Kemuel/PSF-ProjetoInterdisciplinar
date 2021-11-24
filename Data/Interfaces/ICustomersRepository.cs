using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Data.Interfaces
{
    public interface ICustomersRepository
    {
        void Create(Customers customers);
        List<Customers> GetAllCustomers();
        Customers GetSingleCustomer(int id);
        void Update(int id, Customers customers);
        void Delete(int id);

        List<Customers> SearchCustomer(string name);
    }
}
