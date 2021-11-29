using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IEntryEndpoint
    {
        Task PostEntry(EntryModel newEntry);
        Task<EntryModel> LoadEntry(string date);
        Task<List<EntryModel>> LoadEntries();
    }  
}