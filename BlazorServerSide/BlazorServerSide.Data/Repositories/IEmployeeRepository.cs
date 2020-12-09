using BlazorServerSide.Shared.Entities;
using System.Collections.Generic;

namespace BlazorServerSide.Data.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Save(Employee employee);
    }
}