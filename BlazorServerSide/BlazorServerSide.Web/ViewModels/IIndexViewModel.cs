using System.Threading.Tasks;

namespace BlazorServerSide.Web.ViewModels
{
    public interface IIndexViewModel
    {
        string WelcomeMessage { get; set; }

        Task InitialiseViewModel();
    }
}