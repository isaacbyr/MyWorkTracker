using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public class CompanyEndpoint: ICompanyEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public CompanyEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostCompany(CompanyModel company)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/company", company))
            {
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        

        public async Task<CompanyModel> GetCompanyInfo()
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/company"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<CompanyModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task PostEmployee(EmployeeModel employee)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/company/employee", employee))
            {
                if(response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<EmployeeUserModel>> GetEmployees(int companyId)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/company/employee/{companyId}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<EmployeeUserModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<EmployeeDataModel>> GetEmployeeEntries(DateTime date, int companyId)
        {
            var convertedDate = date.ToString("dd-MM-yyyy");
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/company/employee/{companyId}/{convertedDate}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<EmployeeDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<int> LoadCompanyId()
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/company/loadId"))
            {
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<int>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<EmployeeUserModel> LoadOwnerInfo(int companyId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/company/ownerinfo/{companyId}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<EmployeeUserModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
