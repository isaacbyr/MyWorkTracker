using Caliburn.Micro;
using DesktopUI.Library.Api;
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
        private string _username = "i.byron@hotmail.com";
        private string _password = "Test#12";


        public LoginViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
