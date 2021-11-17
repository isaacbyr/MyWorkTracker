using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public class ApiHelper : IApiHelper
    {
        public HttpClient ApiClient { get; set; }

        public ApiHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            // string to the api we want to access. Saved in settings so that it can be changed easier
            string api = ConfigurationSettings.AppSettings["api"];

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(api);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
