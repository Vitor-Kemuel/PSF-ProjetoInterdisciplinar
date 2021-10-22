using System.Collections.Generic;
using ProjectInter.Models;
using System.Linq;

namespace ProjectInter.Repositories
{
    public class CustomerMemoryRepository : ICustomersRepository
    {

        private static List<Customers> customers = new List<Customers>();

        public void Create(Customers customer)
        {
            customers.Add(customer);
        }

        public void Delete(int id)
        {
            var customer = customers.Single(customer => customer.IdPerson == id);
            customers.Remove(customer);
        }

        public Customers GetCustomer(int id)
        {
            return customers.Single(customer => customer.IdPerson == id);
        }

        public List<Customers> GetListCustomers()
        {
            return customers;
        }

        public void Update(int id, Customers model)
        {
            var customer = customers.Single( customer => customer.IdPerson == id);
            customer.IdPerson = model.IdPerson;
            customer.Name = model.Name;
            customer.cpf = model.cpf;
            customer.Cellphone = model.Cellphone;
            customer.Email = model.Email;
            customer.Password = model.Password;
        }
    }
}