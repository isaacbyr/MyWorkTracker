using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Entry")]
    public class EntryController : ApiController
    {
        public void Post(EntryModel newEntry)
        {

            var entryData = new EntryData();

            string id = RequestContext.Principal.Identity.GetUserId();
            newEntry.UserId = id;

            entryData.SaveEntry(newEntry);
        }

        [HttpPut]
        public void Put(EntryModel entry)
        {
            var entryData = new EntryData();

            string id = RequestContext.Principal.Identity.GetUserId();
            entry.UserId = id;

            entryData.UpdateEntry(entry);
        }

        [HttpGet]
        [Route("{date}")]
        public EntryModel Get(string date)
        {
            DateTime convDate;
            DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out convDate);
            string userId = RequestContext.Principal.Identity.GetUserId();

            var entryData = new EntryData();

            return entryData.LoadEntry(convDate, userId);
        }

        [HttpGet]
        [Route("{convFirstDate}/{convLastDate}")]
        public List<EntryModel> Get(string convFirstDate, string convLastDate)
        {
            DateTime firstDate;
            DateTime.TryParseExact(convFirstDate,"dd-MM-yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out firstDate);

            DateTime lastDate;
            DateTime.TryParseExact(convLastDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastDate);

            string userId = RequestContext.Principal.Identity.GetUserId();

            var entryData = new EntryData();

            return entryData.LoadEntries(userId, firstDate, lastDate);
        }

        [Route("{keyword}/{category}/{orderBy}")]
        public List<SearchResultsModel> GetSearchResults(string keyword, string category, string orderBy)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            var entryData = new EntryData();

            return entryData.LoadSearchResults(userId, keyword, category, orderBy);
        }

        [Route("{companyId}/{keyword}/{category}/{orderBy}")]
        public List<SearchResultsEmployeeModel> GetSearchResults(int companyId, string keyword, string category, string orderBy)
        {
          
            var entryData = new EntryData();

            return entryData.LoadAdminSearchResults(companyId, keyword, category, orderBy);
        }
    }
}
