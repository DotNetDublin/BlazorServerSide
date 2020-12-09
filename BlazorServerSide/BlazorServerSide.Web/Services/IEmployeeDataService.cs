using BlazorServerSide.Shared.Entities;
using System.Collections.Generic;

namespace BlazorServerSide.Web.Services
{
    public interface IEmployeeDataService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Save(Employee employee);
    }
}