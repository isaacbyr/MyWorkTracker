using DesktopUI.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DesktopUI.Library.Api
{
   public class UserEndpoint: IUserEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public UserEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task LogUser(LoggedInUserModel user)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/user", user))
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

        public async Task<List<LoggedInUserModel>> GetUserById()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/user"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<List<LoggedInUserModel>>(result);
                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<IsAdminUserModel> LoadAdminStatus()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/user/adminstatus"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IsAdminUserModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
        public async Task ApproveUserRequest(AcceptedUserModel acceptedUser)
        {
            
            using(HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("/api/user", acceptedUser))
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

        public async Task<EditEmployeeUserModel> GetEmployeeById(string id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/user/{id}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<EditEmployeeUserModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<decimal> LoadUserWage()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/user/wage"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<decimal>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task UpdateEmployee(UpdatedEmployeeUserModel updatedEmployee)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("/api/user/employee", updatedEmployee))
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
    }
}
