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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        [Authorize]
        public List<LoggedInUserModel> Get()
        {
            string id = RequestContext.Principal.Identity.GetUserId();

            var userData = new UserData();

            return userData.GetUserById(id);
        }

        public void Post(LoggedInUserModel user)
        {
            var userData = new UserData();

            user.Id = RequestContext.Principal.Identity.GetUserId();

            userData.PostNewUser(user);
        }

        [Route("adminstatus")]
        public IsAdminUserModel GetAdminStatus()
        {
            var userData = new UserData();

            string id = RequestContext.Principal.Identity.GetUserId();

            return userData.LoadAdminStatus(id);
        }
    }
}
