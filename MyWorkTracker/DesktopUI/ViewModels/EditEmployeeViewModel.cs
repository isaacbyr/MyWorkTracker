using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class EditEmployeeViewModel: Screen
    {
        private readonly IUserEndpoint _userEndpoint;
        private readonly IEventAggregator _events;

        public string UserId { get; set; }

        public EditEmployeeViewModel(IUserEndpoint userEndpoint, IEventAggregator events)
        {
            _userEndpoint = userEndpoint;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadEmployee();
        }

        private async Task LoadEmployee()
        {
            var result = await _userEndpoint.GetEmployeeById(UserId);
            if(result != null)
            {
                FirstName = result.FirstName;
                LastName = result.LastName;
                Wage = Math.Round(result.Wage,2);
                BilledOut = Math.Round(result.BilledOut,2);
            }
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

        private decimal _wage;

        public decimal Wage
        {
            get { return _wage; }
            set 
            { 
                _wage = value;
                NotifyOfPropertyChange(() => Wage);
            }
        }

        private decimal _billedOut;

        public decimal BilledOut
        {
            get { return _billedOut; }
            set 
            { 
                _billedOut = value;
                NotifyOfPropertyChange(() => BilledOut);
            }
        }

        public void RemoveEmployee()
        {

        }

        public void ReturnHome()
        {
            _events.PublishOnUIThread(new ReturnToAdminAccountEvent());
        }

        public async Task UpdateEmployee()
        {
            var updatedEmployee = new UpdatedEmployeeUserModel
            {
                Id = UserId,
                Wage = Wage,
                BilledOut = BilledOut
            };

            await _userEndpoint.UpdateEmployee(updatedEmployee);

            ReturnHome();
        }
    }
}
