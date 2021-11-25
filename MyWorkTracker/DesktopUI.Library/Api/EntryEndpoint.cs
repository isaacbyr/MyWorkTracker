using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public class EntryEndpoint: IEntryEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public EntryEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
      
        public async Task PostEntry(EntryModel newEntry)
        {
            using (HttpResponseMessage response =  await _apiHelper.ApiClient.PostAsJsonAsync("api/Entry", newEntry))
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

        public async Task<EntryModel> LoadEntry ()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/entry"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<EntryModel>();
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
