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

        public void Cancel()
        {
            _events.PublishOnUIThread(new CloseEntryView());
        }
    }
}
