using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        private readonly LoginViewModel _loginView;

        public ShellViewModel(LoginViewModel loginView)
        {
            _loginView = loginView;


            ActivateItem(_loginView);
        }
    }
}
