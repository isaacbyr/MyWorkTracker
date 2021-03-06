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
    public class SearchViewModel: Screen
    {
        private readonly IEntryEndpoint _entryEndpoint;
        private readonly IEventAggregator _events;

        public SearchViewModel(IEntryEndpoint entryEndpoint, IEventAggregator events)
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

        private List<string> _categories = new List<string> { "Job", "Location"};

        public List<string> Categories
        {
            get { return _categories; }
            set 
            { 
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        private List<string> _orderByList = new List<string> { "Date (Newest)", "Total (Asc)" , "Total (Desc)", "Date (Oldest)" };

        public List<string> OrderByList
        {
            get { return _orderByList; }
            set 
            { 
                _orderByList = value;
                NotifyOfPropertyChange(() => OrderByList);
            }
        }

        private BindingList<SearchResultsModel> _results;

        public BindingList<SearchResultsModel> Results
        {
            get { return _results; }
            set 
            { 
                _results = value;
                NotifyOfPropertyChange(() => Results);
            }
        }

        private SearchResultsModel _selectedResult;

        public SearchResultsModel SelectedResult
        {
            get { return _selectedResult; }
            set 
            { 
                _selectedResult = value;
                NotifyOfPropertyChange(() => SelectedResult);
            }
        }


        public void OpenEntryView()
        {
            DateTime date;
            DateTime.TryParseExact(SelectedResult.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            var content = date.Day.ToString("");
            _events.PublishOnUIThread(new CreateNewEvent(content, false, false, date));
        }


        public async Task Search()
        {
            var searchInput = new SearchInputModel
            {
                Keyword = Keyword,
                Category = SelectedCategory,
                OrderBy = SelectedOrderBy
            };

            var results = await _entryEndpoint.LoadSearchResults(searchInput);
            foreach (var r in results)
            {
                r.Date = r.Date.Substring(0, 10);
                r.Wage = Math.Round(r.Wage, 2);
                r.SubTotal = Math.Round(r.SubTotal, 2);
            }
            Results = new BindingList<SearchResultsModel>(results);
            
        }
        public void ReturnHome()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    }
}
