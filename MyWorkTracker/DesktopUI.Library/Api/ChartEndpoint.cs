using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public class ChartEndpoint : IChartEndpoint
    {

        private readonly IApiHelper _apiHelper;

        public ChartEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<HoursChartDataModel>> LoadHoursChartData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/chart/hours"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<HoursChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<WeeklyChartDataModel>> LoadWeeklyChartData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/chart/weekly"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<WeeklyChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async Task<List<MonthlyChartDataModel>> LoadMonthlyChartData()
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/chart/monthly"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<MonthlyChartDataModel>>();
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
