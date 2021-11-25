﻿using DataManager.Library.DataAccess;
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
    [RoutePrefix("api/NewEntry")]
    public class NewEntryController : ApiController
    {
        public void Post(NewEntryModel newEntry)
        {

            var entryData = new EntryData();

            string id = RequestContext.Principal.Identity.GetUserId();
            newEntry.UserId = id;

            entryData.SaveEntry(newEntry);
        }
    }
}
