using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DesktopUI.EventModels;

namespace DesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {
        private LoginViewModel _loginView;
        private readonly IEventAggregator _events;
        private readonly WelcomeViewModel _welcomeVM;
        private readonly SimpleContainer _container;

        public ShellViewModel(LoginViewModel loginView, IEventAggregator events, WelcomeViewModel welcomeVM, SimpleContainer container)
        {
            _loginView = loginView;
            _events = events;
            _welcomeVM = welcomeVM;
            _container = container;

            // have to subscribe to events in general
            _events.Subscribe(this);

            ActivateItem(_loginView);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_welcomeVM);

            // override current login view model and shows a blank one;

            _loginView = _container.GetInstance<LoginViewModel>();
        }
    }
}
