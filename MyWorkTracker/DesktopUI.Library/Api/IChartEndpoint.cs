using DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IChartEndpoint
    {
        Task<List<MonthlyChartDataModel>> LoadMonthlyChartData();
        Task<List<WeeklyChartDataModel>> LoadWeeklyChartData();
        Task<List<HoursChartDataModel>> LoadHoursChartData();
        Task<List<DailyChartDataModel>> LoadDailyChartData();
        Task<List<JobChartDataModel>> LoadJobTotalsChartData();
        Task<List<LocationChartDataModel>> LoadLocationChartData();
        Task<List<HoursChartDataModel>> LoadHoursChartDataById(string userId);
        Task<List<DailyChartDataModel>> LoadDailyChartDataById(string id);
        Task<List<WeeklyChartDataModel>> LoadWeeklyChartDataById(string id);
        Task<List<MonthlyChartDataModel>> LoadMonthlyChartDataById(string id);
        Task<List<JobChartDataModel>> LoadJobTotalsChartDataById(string id);
        Task<List<LocationChartDataModel>> LoadLocationChartDataById(string id);
    }
}