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

        public bool NextMonth { get; set; }
        public bool PrevMonth { get; set; }
        public DateTime SelectedMonth { get; set; }

        private string _date;

        public string Date
        {
            get { return _date; }
            set 
            { 
                _date = value;
                NotifyOfPropertyChange(() => Date);
                NotifyOfPropertyChange(() => ViewingDate);
            }
        }

        public string ViewingDate
        {
            get
            {
                int currentSelectedMonth = SelectedMonth.Month;
                int currentSelectedYear = SelectedMonth.Year;
                int convertedDay;
                int.TryParse(Date, out convertedDay);
                if(!PrevMonth && !NextMonth)
                {
                  var date = new DateTime(currentSelectedYear, currentSelectedMonth, convertedDay);
                  entry.JobDate = date.ToString("dd/MM/yyyy");
                  return date.ToString("dddd, MMM d yyyy").ToUpper();
                }
                else if (!PrevMonth && NextMonth)
                {
                    var date = new DateTime(currentSelectedYear, currentSelectedMonth+1, convertedDay);
                    entry.JobDate = date.ToString("dd/MM/yyyy");
                    return date.ToString("dddd, MMM d yyyy").ToUpper();
                }
                else if (PrevMonth && !NextMonth)
                {
                    var date = new DateTime(currentSelectedYear, currentSelectedMonth - 1, convertedDay);
                    entry.JobDate = date.ToString("dd/MM/yyyy");
                    return date.ToString("dddd, MMM d yyyy").ToUpper();
                }

                return "Cal Error";
            }
        }


        private readonly IEventAggregator _events;
        private IEntryEndpoint _entryEndpoint;
        public EntryModel entry = new EntryModel();

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
          var foundEntry = await _entryEndpoint.LoadEntry(entry.JobDate);
            if (foundEntry != null)
            {
                Job = foundEntry.Job;
                Location = foundEntry.Location;
                Hours = foundEntry.Hours;
                Wage = foundEntry.Wage;
                Description = foundEntry.Description;
            }
            else
            {
                Job = "";
                Location = "";
                Hours = 0;
                Wage = 0;
                Description ="";
            }

            NotifyOfPropertyChange(() => Job);
            NotifyOfPropertyChange(() => Hours);
            NotifyOfPropertyChange(() => Location);
            NotifyOfPropertyChange(() => Wage);
            NotifyOfPropertyChange(() => Description);
        }

        private string _job;

        public string Job
        {
            get { return _job; }
            set 
            { 
                _job = value;
            }
        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set 
            { 
                _location = value;
                NotifyOfPropertyChange(() => Location);
            }
        }

        private decimal _hours;

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

        private decimal _wage;

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

        private string _description;

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
           
            entry.Job = Job;
            entry.Location = Location;
            entry.Hours = Hours;
            entry.Wage = Wage;
            entry.Subtotal = Subtotal;
            entry.Taxes = Taxes;
            entry.Total = Total;
            entry.Description = Description;

            await _entryEndpoint.PostEntry(entry);

            _events.PublishOnUIThread(new SavedToDbEvent());

        }
    }
}
