using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Repositories
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);

        List<Employee> GetListEmployees();

        Employee GetEmployee(int id);

        void Update(int id, Employee employee);

        void Delete(int id);
    }
}