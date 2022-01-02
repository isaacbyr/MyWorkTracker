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
    }
}