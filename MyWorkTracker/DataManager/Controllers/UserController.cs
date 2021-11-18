using DataManager.Library.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataManager.Library.DataAccess;

namespace DataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        // Get: User/Details/5
        public List<UserModel> GetById ()
        {
            string id = RequestContext.Principal.Identity.GetUserId();

            var userData = new UserData();

            return userData.GetUserById(id);
        }
    }
}
