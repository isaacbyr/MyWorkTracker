using Caliburn.Micro;
using DesktopUI.EventModels;
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

        public NewEntryViewModel(IEventAggregator events)
        {
            _events = events;
        }

        private string _job;

        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private decimal _hours;

        public decimal Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        private decimal _wage;

        public decimal Wage
        {
            get { return _wage; }
            set { _wage = value; }
        }

        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private decimal _subtotal;

        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
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

        public void Add()
        {

        }
    }
}
