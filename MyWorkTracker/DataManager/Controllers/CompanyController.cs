using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataManager.Controllers
{
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        public void Post(CompanyModel company)
        {
            var companyData = new CompanyData();

            company.OwnerId = RequestContext.Principal.Identity.GetUserId();

            companyData.PostCompany(company);
        }

        public CompanyModel Get()
        {
            var companyData = new CompanyData();

            string id = RequestContext.Principal.Identity.GetUserId();

            return companyData.GetCompanyInfo(id);
        }

        [Route("employee")]
        public void PostEmployee(EmployeeModel employee)
        {
            var companyData = new CompanyData();

            companyData.PostEmployee(employee);
        }

        [Route("employee/{companyId}")]
        public List<EmployeeUserModel> GetEmployees(int companyId)
        {
            var companyData = new CompanyData();

            return companyData.GetEmployees(companyId);
        }
       
        [Route("employee/{companyId}/{convertedDate}")]
        public List<EmployeeDataModel> GetEmployeeEntries(int companyId, string convertedDate)
        {
            DateTime date;
            DateTime.TryParseExact(convertedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);


            var companyData = new CompanyData();

            return companyData.GetEmployeeEntries(date, companyId);
        }

        [HttpGet]
        [Route("loadId")]
        public int LoadCompanyId()
        {
            var companyData = new CompanyData();

            string id = RequestContext.Principal.Identity.GetUserId();

            return companyData.LoadCompanyId(id);
        }
    }

}
