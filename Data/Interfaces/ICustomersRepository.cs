using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Data.Interfaces
{
    public interface ICustomersRepository
    {
        void Create(Customers customers, Address address);
        List<Customers> GetAllCustomers();
        Customers GetCustomer(int id);
        void Update(int id, Customers customers);
        void Delete(int id);
    }
}