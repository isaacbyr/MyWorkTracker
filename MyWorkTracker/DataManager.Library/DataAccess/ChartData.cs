using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class ChartData
    {

        public List<MonthlyChartDataModel> LoadMonthlyTotals(string UserId)
        {
            var sql = new SqlDataAccess();
            var p = new { UserId = UserId };

            try
            {
                var output = sql.LoadData<MonthlyChartDataModel, dynamic>("dbo.spGroupEntriesByMonth", p, "WTData");
                return output;
            }
            catch
            {
                return null;
            }
        }

        public List<WeeklyChartDataModel> LoadWeeklyTotals (string UserId)
        {
            var sql = new SqlDataAccess();
            var p = new { UserId = UserId };

            try
            {
                var output = sql.LoadData<WeeklyChartDataModel, dynamic>("dbo.spGroupEntriesByWeek", p, "WTData");
                return output;
            }
            catch
            {
                return null;
            }
        }

        public List<HoursChartDataModel> LoadHours (string UserId)
        {
            var sql = new SqlDataAccess();
            var p = new { UserId = UserId };

            try
            {
                var output = sql.LoadData<HoursChartDataModel, dynamic>("dbo.spGetHoursPerDay", p, "WTData");
                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}
