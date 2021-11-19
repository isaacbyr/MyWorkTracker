using Caliburn.Micro;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class WelcomeViewModel: Screen
    {

        private readonly ILoggedInUserModel _loggedInUser;
        private string _currentUserFirstName;

        public string CurrentUserFirstName
        {
            get { return _currentUserFirstName; }
            set 
            { 
                _currentUserFirstName = value;
                NotifyOfPropertyChange(() => CurrentUserFirstName);
            }
        }

        public WelcomeViewModel(ILoggedInUserModel loggedInUser)
        {
            _loggedInUser = loggedInUser;
            CurrentUserFirstName = _loggedInUser.FirstName;
        }

    }
}
