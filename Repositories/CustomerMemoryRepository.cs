using System.Collections.Generic;
using ProjectInter.Models;
using System.Linq;

namespace ProjectInter.Repositories
{
    public class CustomerMemoryRepository : BDContext, ICustomersRepository
    {

        private static List<Customers> customers = new List<Customers>();

        public void Create(Customers customer)
        {
            customers.Add(customer);
        }

        public void Delete(int id)
        {
            var customer = customers.Single(customer => customer.IdCustomers == id);
            customers.Remove(customer);
        }

        public Customers GetCustomer(int id)
        {
            return customers.Single(customer => customer.IdCustomers == id);
        }

        public List<Customers> GetListCustomers()
        {
            return customers;
        }

        public void Update(int id, Customers model)
        {
            var customer = customers.Single( customer => customer.IdCustomers == id);
            customer.IdCustomers = model.IdPerson;
            customer.Name = model.Name;
            customer.cpf = model.cpf;
            customer.Cellphone = model.Cellphone;
            customer.Email = model.Email;
            customer.Password = model.Password;
            customer.FkPerson = model.FkPerson;
            customer.Person = model.Person;
        }
    }
}