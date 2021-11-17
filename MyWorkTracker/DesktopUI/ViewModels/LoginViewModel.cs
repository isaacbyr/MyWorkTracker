using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class LoginViewModel: Screen
    {
        private string _username;
                
        public string UserName
        {
            get { return _username; }
            set 
            { 
                _username = value;
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


    }
}
