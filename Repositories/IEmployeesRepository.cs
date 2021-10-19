using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Repositories
{
    public interface IEmployeesRepository
    {
        void Create(Employees employee);

        List<Employees> GetListEmployees();

        Employees GetEmployee(int id);

        void Update(int id, Employees employee);

        void Delete(int id);
    }
}