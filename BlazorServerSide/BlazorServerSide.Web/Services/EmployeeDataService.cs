using BlazorServerSide.Data.Repositories;
using BlazorServerSide.Shared.Entities;
using System.Collections.Generic;

namespace BlazorServerSide.Web.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDataService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Employee Save(Employee employee)
        {
            return _employeeRepository.Save(employee);
        }
    }
}
