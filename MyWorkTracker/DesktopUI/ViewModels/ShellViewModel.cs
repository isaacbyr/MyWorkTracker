using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;

namespace DesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>, IHandle<CreateNewEvent>, IHandle<LogOffEvent>, IHandle<ExitAppEvent>
    {
        private LoginViewModel _loginView;
        private readonly IEventAggregator _events;
        private readonly WelcomeViewModel _welcomeVM;
        private readonly SimpleContainer _container;
        private HomeViewModel _homeVM;


        public ShellViewModel(LoginViewModel loginView, IEventAggregator events, 
            WelcomeViewModel welcomeVM, SimpleContainer container, HomeViewModel homeVM)
        {
            _loginView = loginView;
            _events = events;
            _welcomeVM = welcomeVM;
            _container = container;
            _homeVM = homeVM;
            

            // have to subscribe to events in general
            _events.Subscribe(this);

            // ActivateItem(_loginView);
            ActivateItem(_homeVM);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_homeVM);
        
            // override current login view model and shows a blank one;

            _loginView = _container.GetInstance<LoginViewModel>();
        }
        public void Handle(CreateNewEvent message)
        {
            ActivateItem(_welcomeVM);


        }

        public void Handle(LogOffEvent message)
        {
            ActivateItem(_loginView);
        }

        public void Handle(ExitAppEvent message)
        {
            TryClose();
        }
    }
}
