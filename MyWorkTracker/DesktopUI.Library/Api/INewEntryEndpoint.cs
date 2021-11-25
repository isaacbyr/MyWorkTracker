using DesktopUI.Library.Models;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface INewEntryEndpoint
    {
        Task PostEntry(EntryModel newEntry);
    }  
}