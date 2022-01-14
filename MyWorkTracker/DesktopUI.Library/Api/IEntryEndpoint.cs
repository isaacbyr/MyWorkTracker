using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IEntryEndpoint
    {
        Task PostEntry(EntryModel newEntry);
        Task<EntryModel> LoadEntry(DateTime date);
        Task<List<EntryModel>> LoadEntriesBetweenDates(DateTime firstDate, DateTime lastDate);
        Task<List<SearchResultsModel>> LoadSearchResults(SearchInputModel searchInput);
        Task<List<SearchResultsEmployeeModel>> LoadAdminSearchResults(AdminSearchInputModel searchInput);
    }  
}