using DesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DesktopUI.Library.Models;
using DesktopUI.EventModels;
using System.Windows;

namespace DesktopUI.ViewModels
{
    public class RegisterViewModel: Screen
    {

        private IApiHelper _apiHelper;
        private readonly IRequestEndpoint _requestEndpoint;
        private readonly IEventAggregator _events;
        private readonly IUserEndpoint _userEndpoint;
        private readonly ICompanyEndpoint _companyEndpoint;

        public RegisterViewModel(IApiHelper apiHelper, IRequestEndpoint requestEndpoint,
            IEventAggregator events, IUserEndpoint userEndpoint, ICompanyEndpoint companyEndpoint )
        {
            _apiHelper = apiHelper;
            _requestEndpoint = requestEndpoint;
            _events = events;
            _userEndpoint = userEndpoint;
            _companyEndpoint = companyEndpoint;
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

        private bool _isAdmin = false;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set 
            { 
                _isAdmin = value;
                NotifyOfPropertyChange(() => IsAdmin);
            }
        }

        private bool _isNotAdmin = true;

        public bool IsNotAdmin
        {
            get { return _isNotAdmin; }
            set 
            { 
                _isNotAdmin = value;
                NotifyOfPropertyChange(() => IsNotAdmin);
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

        private int _companyId;

        public int CompanyId
        {
            get { return _companyId; }
            set 
            { 
                _companyId = value;
                NotifyOfPropertyChange(() => CompanyId);
            }
        }



        public void HandleClick(RoutedEventArgs e)
        {
            IsAdmin = !IsAdmin;
            IsNotAdmin = !IsNotAdmin;
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
            var logUserModel = new LoggedInUserModel();
            var company = new CompanyModel();
            var approvalReq = new ApprovalRequestModel();

            user.Email = UserName;
            user.Password = Password;
            user.ConfirmPassword = ConfirmPassword;

            logUserModel.FirstName = FirstName;
            logUserModel.LastName = LastName;
            logUserModel.Email = UserName;
            if(IsAdmin)
            {
                logUserModel.Company = Company;
                logUserModel.IsApproved = true;
            }
            else
            {
                logUserModel.Company = "No Company";
                logUserModel.IsApproved = false;
            }
            
            logUserModel.IsAdmin = IsAdmin;
            logUserModel.CreatedAt = DateTime.Now;
            

            company.Name = Company;

            try
            {
                await _apiHelper.RegisterUser(user);

                var result = await _apiHelper.Authenticate(user.Email, user.Password);

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                await _userEndpoint.LogUser(logUserModel);

                if (IsAdmin)
                {
                    await _companyEndpoint.PostCompany(company);
                }
                else
                {
                    approvalReq.CompanyId = CompanyId;
                    approvalReq.Approved = false;

                    await _requestEndpoint.SendApproval(approvalReq);
                }
                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
