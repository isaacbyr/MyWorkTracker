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

        private string _firstName = "Sue";

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        private string _lastName = "Beckley";

        public string LastName
        {
            get { return _lastName; }
            set
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        private string _company = "Seaside Gardens";

        public string Company
        {
            get { return _company; }
            set 
            { 
                _company = value;
                NotifyOfPropertyChange(() => Company);
            }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set 
            { 
                _isAdmin = value;
                NotifyOfPropertyChange(() => IsAdmin);
            }
        }


        private string _userName = "sbeckley@shaw.ca";

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        private string _password = "Lucy#12";

        public string Password
        {
            get { return _password; }
            set
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private string _confirmPassword = "Lucy#12";

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set 
            { 
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
            }
        }

        public void CanRegister ()
        {

        }

        public void Cancel ()
        {
            _events.PublishOnUIThread(new CloseRegisterView());
        }

        public async Task Register ()
        {

            var user = new RegisterUserModel();

            string isAdmin = IsAdmin.ToString();

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = UserName;
            user.Company = Company;
            user.Password = Password;
            user.ConfirmPassword = ConfirmPassword;
            user.IsAdmin = isAdmin;

            try
            {
                await _apiHelper.RegisterUser(user);

                var result = await _apiHelper.Authenticate(user.Email, user.Password);

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                //await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
