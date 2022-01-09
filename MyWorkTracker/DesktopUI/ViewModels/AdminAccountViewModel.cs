using AutoMapper;
using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    //TODO: Add Way for admin to add company phone and address

    public class AdminAccountViewModel: Screen
    {

        private readonly IEventAggregator _events;
        private readonly IUserEndpoint _userEndpoint;
        IMapper _mapper;
        private readonly ICompanyEndpoint _companyEndpoint;
        private readonly IRequestEndpoint _requestEndpoint;

        public AdminAccountViewModel(IEventAggregator events, IUserEndpoint userEndpoint, IMapper mapper,
            ICompanyEndpoint companyEndpoint, IRequestEndpoint requestEndpoint)
        {
            _events = events;
            _userEndpoint = userEndpoint;
            _mapper = mapper;
            _companyEndpoint = companyEndpoint;
            _requestEndpoint = requestEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadUserData();
            await LoadCompanyData();
            await LoadRequests();
            await LoadEmployees();
        }

        public async Task LoadEmployees()
        {
            int companyId;
            int.TryParse(CompanyId, out companyId);
            var employeeList = await _companyEndpoint.GetEmployees(companyId);

            Employees = new BindingList<EmployeeUserModel>(employeeList);

            NumEmployees = Employees.Count().ToString();
        }

        public async Task LoadRequests()
        {
            int companyId;
            int.TryParse(CompanyId, out companyId);
            var requestList =  await _requestEndpoint.LoadRequests(companyId);

            //var requests = _mapper.Map<List<ApprovalRequestModel>>(requestList);
            Requests = new BindingList<UserRequestModel>(requestList);
        }

        private BindingList<UserRequestModel> _requests;

        public BindingList<UserRequestModel> Requests
        {
            get { return _requests; }
            set
            {
                _requests = value;
                NotifyOfPropertyChange(() => Requests);
            }
        }

        private BindingList<EmployeeUserModel> _employees;

        public BindingList<EmployeeUserModel> Employees
        {
            get { return _employees; }
            set 
            { 
                _employees = value;
                NotifyOfPropertyChange(() => Employees);
            }
        }


        public async Task LoadCompanyData()
        {
           var result = await _companyEndpoint.GetCompanyInfo();

            if(result != null)
            {
                CompanyId = result.Id.ToString();
                Company = result.Name;
            }
        }

        private string _companyId;

        public string CompanyId
        {
            get { return _companyId; }
            set 
            { 
                _companyId = value;
                NotifyOfPropertyChange(() => CompanyId);
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

        private string _company;

        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                NotifyOfPropertyChange(() => Company);
            }
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

        private string _numEmployees;

        public string NumEmployees
        {
            get { return _numEmployees; }
            set 
            { 
                _numEmployees = value;
                NotifyOfPropertyChange(() => NumEmployees);
            }
        }


        private string _role;

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                NotifyOfPropertyChange(() => Role);
            }
        }

        private string _isApproved;

        public string IsApproved
        {
            get { return _isApproved; }
            set
            {
                _isApproved = value;
                NotifyOfPropertyChange(() => IsApproved);
            }
        }

        private UserRequestModel _selectedUser;

        public UserRequestModel SelectedUser
        {
            get { return _selectedUser; }
            set
            { 
                _selectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
                NotifyOfPropertyChange(() => Requests);
            }
        }

        private EmployeeUserModel _selectedEmployee;

        public EmployeeUserModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set 
            {
                _selectedEmployee = value;
                NotifyOfPropertyChange(() => SelectedEmployee);
            }
        }



        public async Task LoadUserData()
        {
            var result = await _userEndpoint.GetUserById();

            if (result != null)
            {
                FirstName = result[0].FirstName;
                LastName = result[0].LastName;
                //Company = result[0].Company;
                UserName = result[0].Email;
                IsApproved = result[0].IsApproved.ToString();

                if (result[0].IsAdmin.Equals(true))
                {
                    Role = "Owner";
                }
                else
                {
                    Role = "Employee";
                }
            }

        }

        public async Task Accept()
        {
            await _requestEndpoint.RemoveRequest(SelectedUser.Id);

            var acceptedUser = new AcceptedUserModel
            {
                Id = SelectedUser.Id,
                Company = Company
            };

            await _userEndpoint.ApproveUserRequest(acceptedUser);

            int companyId;
            int.TryParse(CompanyId, out companyId);

            var employee = new EmployeeModel
            {
                CompanyId = companyId,
                EmployeeId = SelectedUser.Id
            };

            await _companyEndpoint.PostEmployee(employee);

            await LoadRequests();
            await LoadEmployees();
        }

        public async Task EditEmployee()
        {
            _events.PublishOnUIThread(new OpenEditEmployeeEvent(SelectedEmployee.Id));
            //await _userEndpoint.GetEmployeeById(SelectedEmployee.Id);
        }

        public async Task Delete()
        {
            
            await _requestEndpoint.RemoveRequest(SelectedUser.Id);

            await LoadRequests();
        }

        public void Logout()
        {
            _events.PublishOnUIThread(new LogOffEvent());
        }

        public void Home()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    
    }
}
