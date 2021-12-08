using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataManager.Controllers
{
    [RoutePrefix("api/Chart")]
    public class ChartController : ApiController
    {
        [Route("monthly")]
        public List<MonthlyChartDataModel> GetMonthData ()
        {
            var chartData = new ChartData();

            string UserId = RequestContext.Principal.Identity.GetUserId();

            return chartData.LoadMonthlyTotals(UserId);
        }

        [Route("weekly")]
        public List<WeeklyChartDataModel> GetWeekData ()
        {
            var chartData = new ChartData();

            string UserId = RequestContext.Principal.Identity.GetUserId();

            return chartData.LoadWeeklyTotals(UserId);
        }

        [Route("hours")]
        public List<HoursChartDataModel> GetHoursData()
        {
            var chartData = new ChartData();

            string UserId = RequestContext.Principal.Identity.GetUserId();

            return chartData.LoadHours(UserId);
        }
    }
}
