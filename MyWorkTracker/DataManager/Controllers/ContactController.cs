using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataManager.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        public void PostContact(ContactModel contact)
        {
            var contactData = new ContactData();

            contactData.PostContact(contact);
        }

        [Route("{companyId}")]
        public List<ContactModel> GetContact(int companyId)
        {
            var contactData = new ContactData();

            return contactData.LoadContacts(companyId);
        }
    }
}
