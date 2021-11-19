using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Data.Interfaces
{
    public interface IEmployeesRepository
    {
        void Create(Employees employee);

        List<Employees> GetListEmployees();

        Employees GetSingleEmployee(int id);

        void Update(int id, Employees employee);

        Employees Login(Employees employee);

        void Delete(int id);
    }
}
