using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public class ContactEndpoint: IContactEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public ContactEndpoint(IApiHelper apiHelper)
        {
           _apiHelper = apiHelper;
        }

        public async Task PostContact(ContactModel contact)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/contact", contact))
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

        public async Task<List<ContactModel>> GetContacts(int companyId)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/contact/{companyId}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ContactModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
