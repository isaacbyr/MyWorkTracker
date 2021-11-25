﻿using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public class NewEntryEndpoint: INewEntryEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public NewEntryEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
      
        public async Task PostEntry(EntryModel newEntry)
        {
            using (HttpResponseMessage response =  await _apiHelper.ApiClient.PostAsJsonAsync("api/NewEntry", newEntry))
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
    }
}
