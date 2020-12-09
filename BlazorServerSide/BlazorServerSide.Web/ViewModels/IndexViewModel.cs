using BlazorServerSide.Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Web.ViewModels
{
    public class IndexViewModel : IIndexViewModel
    {
        public IndexViewModel(IEmployeeDataService employeeDataService)
        {
            EmployeeDataService = employeeDataService;
        }

        private IEmployeeDataService EmployeeDataService { get; set; }
        public string WelcomeMessage { get; set; }

        public async Task InitialiseViewModel()
        {
            await Task.Delay(0);

            int employeeRecordCount = EmployeeDataService.GetAll().Count();

            WelcomeMessage = $"There are currently {employeeRecordCount} employee records";
        }
    }
}
