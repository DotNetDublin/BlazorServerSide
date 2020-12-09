using BlazorServerSide.Shared.Entities;
using BlazorServerSide.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerSide.Web.ViewModels
{
    public class EmployeeListingViewModel : IEmployeeListingViewModel
    {
        public EmployeeListingViewModel(IEmployeeDataService employeeDataService)
        {
            EmployeeDataService = employeeDataService;
        }

        private IEmployeeDataService EmployeeDataService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public async Task InitialiseViewModel()
        {
            await Task.Delay(0);

            Employees = EmployeeDataService.GetAll();
        }
    }
}
