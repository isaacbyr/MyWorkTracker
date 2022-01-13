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

        public async Task<List<JobChartDataModel>> LoadJobTotalsChartData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/chart/jobs"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<JobChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<DailyChartDataModel>> LoadDailyChartData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/chart/daily"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<DailyChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<LocationChartDataModel>> LoadLocationChartData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/chart/location"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<LocationChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<HoursChartDataModel>> LoadHoursChartDataById(string userId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/chart/hours/{userId}"))
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

        public async Task<List<DailyChartDataModel>> LoadDailyChartDataById(string id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/chart/daily/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<DailyChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<WeeklyChartDataModel>> LoadWeeklyChartDataById(string id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/chart/weekly/{id}"))
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

        public async Task<List<MonthlyChartDataModel>> LoadMonthlyChartDataById(string id)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/chart/monthly/{id}"))
            {
                if (response.IsSuccessStatusCode)
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

        public async Task<List<JobChartDataModel>> LoadJobTotalsChartDataById(string id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/chart/jobs/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<JobChartDataModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<LocationChartDataModel>> LoadLocationChartDataById(string id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/chart/location/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<LocationChartDataModel>>();
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
