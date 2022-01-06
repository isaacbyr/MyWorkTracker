using DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface ICompanyEndpoint
    {
        Task PostCompany(CompanyModel company);
        Task<CompanyModel> GetCompanyInfo();
        Task PostEmployee(EmployeeModel employee);
        Task<List<EmployeeUserModel>> GetEmployees(int companyId);
    }
}