using Caliburn.Micro;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class LoginViewModel: Screen
    {
        private readonly IApiHelper _apiHelper;
        private readonly ILoggedInUserModel _loggedInUser;
        private string _username = "i.byron@hotmail.com";
        private string _password = "Test#12";


        public LoginViewModel(IApiHelper apiHelper, ILoggedInUserModel loggedInUser)
        {
            _apiHelper = apiHelper;
            _loggedInUser = loggedInUser;
        }

        public string UserName
        {
            get { return _username; }
            set 
            { 
                _username = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(UserName, Password);

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
