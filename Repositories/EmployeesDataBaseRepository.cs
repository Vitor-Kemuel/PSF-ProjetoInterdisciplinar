using System.Collections.Generic;
using ProjectInter.Models;

namespace ProjectInter.Repositories
{
    public class EmployessDataBaseRepository : BDContext, IEmployeeRepository
    {
        public void Create(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> GetListEmployees()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}