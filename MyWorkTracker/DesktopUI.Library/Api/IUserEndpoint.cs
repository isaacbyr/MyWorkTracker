using DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task LogUser(LoggedInUserModel user);
        Task<List<LoggedInUserModel>> GetUserById();
        Task ApproveUserRequest(AcceptedUserModel acceptedUser);
        Task<IsAdminUserModel> LoadAdminStatus();
        Task<decimal> LoadUserWage();
        Task<EditEmployeeUserModel> GetEmployeeById(string id);
        Task UpdateEmployee(UpdatedEmployeeUserModel updatedEmployee);
    }
}