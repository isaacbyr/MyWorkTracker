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
    public class HomeViewModel: Screen
    {
        private readonly IEventAggregator _events;
        private readonly IApiHelper _apiHelper;
        private readonly ILoggedInUserModel _loggedInUser;

        public HomeViewModel(IEventAggregator events, IApiHelper apiHelper, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _apiHelper = apiHelper;
            _loggedInUser = loggedInUser;
        }

        public void New()
        {
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

        public void Logout()
        {
            _apiHelper.Logout();
            _loggedInUser.ResetUser();
            _events.PublishOnUIThread(new LogOffEvent());   
        }

        public void Exit()
        {
            _events.PublishOnUIThread(new ExitAppEvent());
        }

    }
}
