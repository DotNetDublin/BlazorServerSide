using BlazorServerSide.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerSide.Web.ViewModels
{
    public interface IEmployeeListingViewModel
    {
        IEnumerable<Employee> Employees { get; set; }

        Task InitialiseViewModel();
    }
}