using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class AccountViewModel: Screen
    {
        private readonly IEventAggregator _events;
        private readonly IUserEndpoint _userEndpoint;

        public AccountViewModel(IEventAggregator events, IUserEndpoint userEndpoint)
        {
            _events = events;
            _userEndpoint = userEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadUserData();
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        private string _company;

        public string Company
        {
            get { return _company; }
            set 
            { 
                _company = value;
                NotifyOfPropertyChange(() => Company);
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

    
        private string _role;

        public string Role
        {
            get { return _role; }
            set 
            { 
                _role = value;
                NotifyOfPropertyChange(() => Role);
            }
        }

        private string _isApproved;

        public string IsApproved
        {
            get { return _isApproved; }
            set 
            { 
                _isApproved = value;
                NotifyOfPropertyChange(() => IsApproved);
            }
        }


        public async Task LoadUserData()
        {
            var result = await _userEndpoint.GetUserById();

            if(result != null)
            {
                FirstName = result[0].FirstName;
                LastName = result[0].LastName;
                Company = result[0].Company;
                UserName = result[0].Email;
                IsApproved = result[0].IsApproved.ToString();

                if (result[0].IsAdmin.Equals(true))
                {
                    Role = "Owner";
                }
                else
                {
                    Role = "Employee";
                }
            }

        }

        public void Logout()
        {
            _events.PublishOnUIThread(new LogOffEvent());
        }

        public void Home()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    }
}
