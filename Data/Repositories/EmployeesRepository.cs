using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;

namespace ProjectInter.Data.Repositories
{
    public class EmployessRepository : BDContext, IEmployeesRepository
    {
        public void Create(Employees employee)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employees GetEmployee(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employees> GetListEmployees()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Employees employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
