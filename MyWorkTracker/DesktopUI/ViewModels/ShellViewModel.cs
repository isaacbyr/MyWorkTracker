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
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>, IHandle<CreateNewEvent>, IHandle<LogOffEvent>, IHandle<ExitAppEvent>,
        IHandle<CloseEntryView>, IHandle<SavedToDbEvent>, IHandle<OpenRegisterView>, IHandle<CloseRegisterView>, IHandle<OpenStatsView>, 
        IHandle<ReturnHomeEvent>, IHandle<OpenAccountEvent>, IHandle<OpenAdminAccountEvent>, IHandle<AdminCreateNewEvent>, 
        IHandle<OpenEditEmployeeEvent>, IHandle<ReturnToAdminAccountEvent>, IHandle<OpenContactsEvent>, IHandle<OpenAdminStatsView>,
        IHandle<OpenSearchEvent>, IHandle<OpenAdminSearchEvent>
    {
        private LoginViewModel _loginView;
        private readonly IEventAggregator _events;
        private readonly WelcomeViewModel _welcomeVM;
        private readonly SimpleContainer _container;
        private HomeViewModel _homeVM;
        private NewEntryViewModel _newVM;
        private readonly RegisterViewModel _registerVM;
        private readonly StatsViewModel _statsVM;
        private readonly AccountViewModel _accountVM;
        private readonly AdminAccountViewModel _adminAccountVM;
        private readonly AdminNewEntryViewModel _adminNewEntryVM;
        private readonly EditEmployeeViewModel _editEmployeeVM;
        private readonly ContactsViewModel _contactsVM;
        private readonly AdminStatsViewModel _adminStatsVM;
        private readonly SearchViewModel _searchVM;
        private readonly AdminSearchViewModel _adminSearchVM;

        public ShellViewModel(LoginViewModel loginView, IEventAggregator events, 
            WelcomeViewModel welcomeVM, SimpleContainer container, HomeViewModel homeVM, 
            NewEntryViewModel newVM, RegisterViewModel registerVM, StatsViewModel statsVM,
            AccountViewModel accountVM, AdminAccountViewModel adminAccountVM, 
            AdminNewEntryViewModel adminNewEntryVM, EditEmployeeViewModel editEmployeeVM,
            ContactsViewModel contactsVM, AdminStatsViewModel adminStatsVM, SearchViewModel searchVM,
            AdminSearchViewModel adminSearchVM)
        {
            _loginView = loginView;
            _events = events;
            _welcomeVM = welcomeVM;
            _container = container;
            _homeVM = homeVM;
            _newVM = newVM;
            _registerVM = registerVM;
            _statsVM = statsVM;
            _accountVM = accountVM;
            _adminAccountVM = adminAccountVM;
            _adminNewEntryVM = adminNewEntryVM;
            _editEmployeeVM = editEmployeeVM;
            _contactsVM = contactsVM;
            _adminStatsVM = adminStatsVM;
            _searchVM = searchVM;
            _adminSearchVM = adminSearchVM;

            // have to subscribe to events in general
            _events.Subscribe(this);

            ActivateItem(_loginView);
            // ActivateItem(_homeVM);
            //ActivateItem(_statsVM);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_homeVM);

            // override current login view model and shows a blank one;

            _loginView = _container.GetInstance<LoginViewModel>();
        }

        public void Handle(LogOffEvent message)
        {
            ActivateItem(_loginView);
        }

        public void Handle(ExitAppEvent message)
        {
            this.TryClose();
        }

        public void Handle(CreateNewEvent message)
        {
            _newVM.Date = message.Date;
            _newVM.NextMonth = message.NextMonth;
            _newVM.PrevMonth = message.PrevMonth;
            _newVM.SelectedMonth = message.SelectedDate;
            ActivateItem(_newVM);
        }

        public void Handle(CloseEntryView message)
        {
            DeactivateItem(_newVM, true);
            ActivateItem(_homeVM);
        }

        public void Handle(SavedToDbEvent message)
        {
            DeactivateItem(_newVM, true);
            ActivateItem(_homeVM);
        }

        public void Handle(OpenRegisterView message)
        {
            DeactivateItem(_newVM, true);
            ActivateItem(_registerVM);
        }

        public void Handle(CloseRegisterView message)
        {
            DeactivateItem(_registerVM, true);
            ActivateItem(_loginView);
        }

        public void Handle(OpenStatsView message)
        {
           // DeactivateItem(_homeVM, true);
            ActivateItem(_statsVM);
        }

        public void Handle(ReturnHomeEvent message)
        {
            ActivateItem(_homeVM);
        }

        public void Handle(OpenAccountEvent message)
        {
            ActivateItem(_accountVM);
        }

        public void Handle(OpenAdminAccountEvent message)
        {
            ActivateItem(_adminAccountVM);
        }

        public void Handle(AdminCreateNewEvent message)
        {
            _adminNewEntryVM.Date = message.Date;
            _adminNewEntryVM.NextMonth = message.NextMonth;
            _adminNewEntryVM.PrevMonth = message.PrevMonth;
            _adminNewEntryVM.SelectedDate = message.SelectedDate;
            _adminNewEntryVM.CompanyId = message.CompanyId;
            ActivateItem(_adminNewEntryVM);
        }

        public void Handle(OpenEditEmployeeEvent message)
        {
            _editEmployeeVM.UserId = message.Id;
            ActivateItem(_editEmployeeVM);
        }

        public void Handle(ReturnToAdminAccountEvent message)
        {
            ActivateItem(_adminAccountVM);
        }

        public void Handle(OpenContactsEvent message)
        {
            _contactsVM.CompanyId = message.CompanyId;
            ActivateItem(_contactsVM);
        }

        public void Handle(OpenAdminStatsView message)
        {
            _adminStatsVM.CompanyId = message.CompanyId;
            ActivateItem(_adminStatsVM);
        }

        public void Handle(OpenSearchEvent message)
        {
            ActivateItem(_searchVM);
        }

        public void Handle(OpenAdminSearchEvent message)
        {
            _adminSearchVM.CompanyId = message.CompanyId;
            ActivateItem(_adminSearchVM);
        }
    }
}
