using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class AdminSearchViewModel: Screen
    {
        public int CompanyId { get; set; }
        private readonly IEntryEndpoint _entryEndpoint;
        private readonly IEventAggregator _events;

        public AdminSearchViewModel(IEntryEndpoint entryEndpoint, IEventAggregator events)
        {
            _entryEndpoint = entryEndpoint;
            _events = events;
        }


        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                NotifyOfPropertyChange(() => Keyword);
            }
        }

        private string _selectedCategory;

        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }

        private string _selectedOrderBy;

        public string SelectedOrderBy
        {
            get { return _selectedOrderBy; }
            set
            {
                _selectedOrderBy = value;
                NotifyOfPropertyChange(() => SelectedOrderBy);
            }
        }

        private List<string> _categories = new List<string> { "Job", "Location", "Employee" };

        public List<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        private List<string> _orderByList = new List<string> { "Date (Newest)", "Total (Asc)", "Total (Desc)", "Date (Oldest)" };

        public List<string> OrderByList
        {
            get { return _orderByList; }
            set
            {
                _orderByList = value;
                NotifyOfPropertyChange(() => OrderByList);
            }
        }

        private BindingList<SearchResultsEmployeeModel> _results;

        public BindingList<SearchResultsEmployeeModel> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                NotifyOfPropertyChange(() => Results);
            }
        }

        private SearchResultsEmployeeModel _selectedResult;

        public SearchResultsEmployeeModel SelectedResult
        {
            get { return _selectedResult; }
            set
            {
                _selectedResult = value;
                NotifyOfPropertyChange(() => SelectedResult);
            }
        }


        public void OpenAdminEntryView()
        {
            DateTime date;
            DateTime.TryParseExact(SelectedResult.Date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            var content = date.Day.ToString("");
            _events.PublishOnUIThread(new AdminCreateNewEvent(content, false, false, date, CompanyId));
        }


        public async Task Search()
        {
            var searchInput = new AdminSearchInputModel
            {
                CompanyId = CompanyId,
                Keyword = Keyword,
                Category = SelectedCategory,
                OrderBy = SelectedOrderBy
            };

            var results = await _entryEndpoint.LoadAdminSearchResults(searchInput);
            foreach (var r in results)
            {
                r.Date = r.Date.Substring(0, 10);
                r.Wage = Math.Round(r.Wage, 2);
                r.Total = Math.Round(r.Total, 2);
            }
            Results = new BindingList<SearchResultsEmployeeModel>(results);

        }

        public void ReturnHome()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    }
}
    

