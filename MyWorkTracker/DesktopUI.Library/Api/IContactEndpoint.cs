using DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IContactEndpoint
    {
        Task<List<ContactModel>> GetContacts(int companyId);
        Task PostContact(ContactModel contact);
    }
}