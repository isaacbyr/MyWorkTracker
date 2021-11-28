using DesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DesktopUI.Library.Models;
using DesktopUI.EventModels;

namespace DesktopUI.ViewModels
{
    public class RegisterViewModel: Screen
    {

        private IApiHelper _apiHelper;
        private readonly ILoggedInUserModel _loggedInUserModel;
        private readonly IEventAggregator _events;

        public RegisterViewModel(IApiHelper apiHelper, ILoggedInUserModel loggedInUserModel, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _loggedInUserModel = loggedInUserModel;
            _events = events;
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

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set 
            { 
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
            }
        }

        public IApiHelper ApiHelper { get; }

        public void CanRegister ()
        {

        }

        public async Task Register ()
        {
            var result = await _apiHelper.RegisterUser(UserName, Password, ConfirmPassword);

            await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
            _events.PublishOnUIThread(new LogOnEvent());
        }
    }
}
