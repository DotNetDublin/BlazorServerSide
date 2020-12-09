using BlazorServerSide.Shared.Entities;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BlazorServerSide.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly IDbConnection _dbConnection;
        private readonly SqlConnection _db;

        public EmployeeRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }

        public IEnumerable<Employee> GetAll()
        {
            //return _dbConnection.GetAll<Employee>();

            //For demo purposes return hard coded data
            List<Employee> employees = new List<Employee>();

            employees.Add( new Employee{ Id = 1, FirstName = "Bob", LastName = "Smith", DateCreated = DateTime.Today, Department = "Marketing"});
            employees.Add( new Employee{ Id = 2, FirstName = "Lisa", LastName = "Smith", DateCreated = DateTime.Today.AddDays(-7), Department = "Sales"});
            employees.Add( new Employee{ Id = 2, FirstName = "Frank", LastName = "Smith", DateCreated = DateTime.Today.AddDays(-14), Department = "IT"});
            
            return employees;
        }

        public Employee GetById(int id)
        {
            return _dbConnection.Get<Employee>(id);
        }

        public Employee Save(Employee employee)
        {
            if (employee.IsNew)
            {
                employee.DateCreated = DateTime.Now;
                employee.Id = (int)_db.Insert(employee);
            }
            else
            {
                employee.DateModified = DateTime.Now;
                _db.Update(employee);
            }

            return employee;
        }
    }
}
