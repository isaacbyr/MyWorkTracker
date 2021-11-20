using Caliburn.Micro;
using DesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class HomeViewModel: Screen
    {
        private readonly IEventAggregator _events;
        private readonly IWindowManager _manager;

        public HomeViewModel(IEventAggregator events, IWindowManager manager)
        {
            _events = events;
           _manager = manager;
        }

        public void New()
        {
           // _manager.ShowWindow(new WelcomeViewModel(), null, null);
            _events.PublishOnUIThread(new CreateNewEvent());
        }

        private string _currDate = DateTime.Now.ToString("dddd, MMM dd yyyy").ToUpper();

        public string CurrDate
        {
            get { return _currDate; }
            set 
            { 
                _currDate = value;
                NotifyOfPropertyChange(() => CurrDate);
            }
        }


    }
}
