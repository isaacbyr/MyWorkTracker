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

        [HttpGet]
        [Route("{date}")]
        public EntryModel Get(string date)
        {

            string userId = RequestContext.Principal.Identity.GetUserId();

            var entryData = new EntryData();

            return entryData.LoadEntry(date, userId);
        }

        public List<EntryModel> Get()
        {

            string userId = RequestContext.Principal.Identity.GetUserId();

            var entryData = new EntryData();

            return entryData.LoadEntries(userId);
        }
    }
}
