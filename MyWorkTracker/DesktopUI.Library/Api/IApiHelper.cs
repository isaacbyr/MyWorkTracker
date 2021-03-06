using DesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
        void Logout();
        Task RegisterUser(RegisterUserModel user);
    }
}