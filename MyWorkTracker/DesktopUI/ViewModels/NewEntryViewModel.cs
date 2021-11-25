using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class NewEntryViewModel: Screen
    {
        private readonly IEventAggregator _events;
        private IEntryEndpoint _entryEndpoint;

        public NewEntryViewModel(IEventAggregator events, IEntryEndpoint entryEndpoint)
        {
            _events = events;
            _entryEndpoint = entryEndpoint;
        }

        protected override async void OnViewLoaded(object view) 
        {
            await LoadEntry();
        }

        public async Task LoadEntry()
        {
            var loadedEntry = await _entryEndpoint.LoadEntry();
        }

        private string _job;

        public string Job
        {
            get { return _job; }
            set 
            { 
                _job = value;
                NotifyOfPropertyChange(() => Job);
            }
        }

        private string _location = "Musgrave";

        public string Location
        {
            get { return _location; }
            set 
            { 
                _location = value;
                NotifyOfPropertyChange(() => Location);
            }
        }

        private decimal _hours = 4;

        public decimal Hours
        {
            get { return _hours; }
            set 
            { 
                _hours = value;
                NotifyOfPropertyChange(() => Hours);
                NotifyOfPropertyChange(() => Subtotal);
                NotifyOfPropertyChange(() => Total);
                NotifyOfPropertyChange(() => Taxes);
            }
        }

        private decimal _wage = 35;

        public decimal Wage
        {
            get { return _wage; }
            set 
            { 
                _wage = value;
                NotifyOfPropertyChange(() => Wage);
                NotifyOfPropertyChange(() => Subtotal);
                NotifyOfPropertyChange(() => Total);
                NotifyOfPropertyChange(() => Taxes);
            }
        }

        public decimal Total
        {
            get
            {
                return Subtotal - Taxes;
            }
        }

        private string _description = "2 Loads";

        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public decimal Subtotal
        {
            get
            {
                return Wage * Hours;
            }
        }


        public decimal Taxes
        {
            get
            {
                decimal taxRate = 0.015M;
                return taxRate * Subtotal;
            }
        }





        public void Cancel()
        {
            _events.PublishOnUIThread(new CloseEntryView());
        }

        public async Task Add()
        {
            var newEntry = new EntryModel();

            newEntry.Job = Job;
            newEntry.Location = Location;
            newEntry.Hours = Hours;
            newEntry.Wage = Wage;
            newEntry.Subtotal = Subtotal;
            newEntry.Taxes = Taxes;
            newEntry.Total = Total;
            newEntry.Description = Description;

            await _entryEndpoint.PostEntry(newEntry);

        }
    }
}
