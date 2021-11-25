using DesktopUI.Library.Models;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IEntryEndpoint
    {
        Task PostEntry(EntryModel newEntry);
        Task<EntryModel> LoadEntry();
    }  
}