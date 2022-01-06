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
    [RoutePrefix("api/request")]
    public class RequestController : ApiController
    {
        
        public void Post(ApprovalRequestModel approvalReq)
        {
            var requestData = new RequestData();

            approvalReq.UserId = RequestContext.Principal.Identity.GetUserId();

            requestData.PostRequest(approvalReq);
        }

        [Route("{companyId}")]
        public List<UserRequestModel> Get(int companyId)
        {
            var requestData = new RequestData();

            //string id = RequestContext.Principal.Identity.GetUserId();

            return requestData.GetRequests(companyId);
        }

        [Route("delete/{id}")]
        public void Delete(string id)
        {
            var requestData = new RequestData();

            requestData.DeleteRequest(id);
        }
    }
}
