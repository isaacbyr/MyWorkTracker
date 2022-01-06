using DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IRequestEndpoint
    {
        Task SendApproval(ApprovalRequestModel approvalReq);
        Task<List<UserRequestModel>> LoadRequests(int companyId);
        Task RemoveRequest(string id);
    }
}