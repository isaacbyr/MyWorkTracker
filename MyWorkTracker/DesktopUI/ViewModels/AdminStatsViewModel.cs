using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class AdminStatsViewModel: Screen
    {
        private readonly ICompanyEndpoint _companyEndpoint;
        private readonly IChartEndpoint _chartEndpoint;
        private readonly IEventAggregator _events;

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<decimal, string> Formatter { get; set; }

        public int CompanyId { get; set; }

        public AdminStatsViewModel(ICompanyEndpoint companyEndpoint, IChartEndpoint chartEndpoint, IEventAggregator events)
        {
            _companyEndpoint = companyEndpoint;
            _chartEndpoint = chartEndpoint;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadAdminData();
            await LoadUsers();
        }

        public async Task LoadAdminData()
        {
            AdminData = await _companyEndpoint.LoadOwnerInfo(CompanyId);
            AdminData.LastName = AdminData.LastName + " (Me)";
        }

        public async Task LoadUsers()
        {
           var usersList = await _companyEndpoint.GetEmployees(CompanyId);

            Users = new BindingList<EmployeeUserModel>(usersList);

            Users.Add(AdminData);

            var company = new EmployeeUserModel
            {
                Id = CompanyId.ToString(),
                FirstName = "Company",
                LastName = "(All Users)"
            };

            Users.Add(company);
        }

        public async Task LoadDailyTotals()
        {
            Labels = new List<string>(); 
            SeriesCollection = new SeriesCollection();

            foreach (var user in SelectedUsers)
            {
                var data = await _chartEndpoint.LoadDailyChartDataById(user.Id);

                SeriesCollection.Add(
                new ColumnSeries
                {
                    Title = $"{user.FirstName} Totals",
                    Values = new ChartValues<decimal>(data.Select(entry => entry.Total)),
                }
                );

                //Labels = new string[data.Count];
                foreach (DateTime date in data.Select(entry => entry.Date))
                {
                    Labels.Add(date.ToString("dd, MMM, yy"));
                }
            }
            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }


        public async Task LoadWeeklyTotals()
        {
            Labels = new List<string>();
            SeriesCollection = new SeriesCollection();

            foreach (var user in SelectedUsers)
            {
                var data = await _chartEndpoint.LoadWeeklyChartDataById(user.Id);

                SeriesCollection.Add(
                new ColumnSeries
                {
                    Title = $"{user.FirstName} Totals",
                    Values = new ChartValues<decimal>(data.Select(entry => entry.Total)),
                }
                );

                //Labels = new string[data.Count];
                foreach (string date in data.Select(entry => entry.Week))
                {
                    Labels.Add(date);
                }
            }
            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }


        public async Task LoadMonthlyTotals()
        {
            Labels = new List<string>();
            SeriesCollection = new SeriesCollection();

            foreach (var user in SelectedUsers)
            {
                var data = await _chartEndpoint.LoadMonthlyChartDataById(user.Id);

                SeriesCollection.Add(
                new ColumnSeries
                {
                    Title = $"{user.FirstName} Totals",
                    Values = new ChartValues<decimal>(data.Select(entry => entry.Total)),
                }
                );

                //Labels = new string[data.Count];
                foreach (string date in data.Select(entry => entry.Month))
                {
                    Labels.Add(date);
                }
            }
            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }

        public async Task LoadHoursChart()
        {
            Labels = new List<string>();
            SeriesCollection = new SeriesCollection();

            foreach (var user in SelectedUsers)
            {
                var data = await _chartEndpoint.LoadHoursChartDataById(user.Id);

                SeriesCollection.Add(
                new LineSeries
                {
                    Title = $"{user.FirstName} Hours",
                    Values = new ChartValues<decimal>(data.Select(entry => entry.Hours)),
                    Fill = System.Windows.Media.Brushes.Transparent
                }
                );

                //Labels = new string[data.Count];
                int index = 0;
                foreach (DateTime date in data.Select(entry => entry.Date))
                {
                    Labels.Add(date.ToString("dd, MMM, yy"));
                    index += 1;
                }
            }
            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }

        public async Task LoadJobTotals()
        {
            Labels = new List<string>();
            SeriesCollection = new SeriesCollection();

            foreach (var user in SelectedUsers)
            {
                var data = await _chartEndpoint.LoadJobTotalsChartDataById(user.Id);

                SeriesCollection.Add(
                new ColumnSeries
                {
                    Title = $"{user.FirstName} Totals",
                    Values = new ChartValues<decimal>(data.Select(entry => entry.Total)),
                }
                );

                //Labels = new string[data.Count];
                foreach (string job in data.Select(entry => entry.Job))
                {
                    Labels.Add(job);
                }
            }
            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }

        public async Task LoadLocationTotals()
        {
            Labels = new List<string>();
            SeriesCollection = new SeriesCollection();

            foreach (var user in SelectedUsers)
            {
                var data = await _chartEndpoint.LoadLocationChartDataById(user.Id);

                SeriesCollection.Add(
                new ColumnSeries
                {
                    Title = $"{user.FirstName} Totals",
                    Values = new ChartValues<decimal>(data.Select(entry => entry.Total)),
                }
                );

                //Labels = new string[data.Count];
                foreach (string location in data.Select(entry => entry.Location))
                {
                    Labels.Add(location);
                }
            }
            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }


        private List<string> _statistics = new List<string> { "Hours", "Monthly", "Daily", "Weekly", "Job", "Location" };

        public List<string> Statistics
        {
            get { return _statistics; }
            set 
            { 
                _statistics = value;
                NotifyOfPropertyChange(() => Statistics);
            }
        }

        private string _selectedStat;

        public string SelectedStat
        {
            get { return _selectedStat; }
            set 
            {
                _selectedStat = value;
                NotifyOfPropertyChange(() => SelectedStat);
            }
        }


        private BindingList<EmployeeUserModel> _users;

        public BindingList<EmployeeUserModel> Users
        {
            get { return _users; }
            set
            { 
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        private EmployeeUserModel _selectedUser;

        public EmployeeUserModel SelectedUser
        {
            get { return _selectedUser; }
            set 
            {
                _selectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        private EmployeeUserModel _selectedUserListBox;

        public EmployeeUserModel SelectedUserListBox
        {
            get { return _selectedUserListBox; }
            set 
            { 
                _selectedUserListBox = value;
                NotifyOfPropertyChange(() => SelectedUserListBox);
            }
        }


        private BindingList<EmployeeUserModel> _selectedUsers = new BindingList<EmployeeUserModel>();

        public BindingList<EmployeeUserModel> SelectedUsers
        {
            get { return _selectedUsers; }
            set 
            { 
                _selectedUsers = value;
                NotifyOfPropertyChange(() => SelectedUsers);
            }
        }

        private EmployeeUserModel _adminData;

        public EmployeeUserModel AdminData
        {
            get { return _adminData; }
            set 
            {
                _adminData = value;
                NotifyOfPropertyChange(() => AdminData);
            }
        }


        private string y_title = "Totals";

        public string Y_Title
        {
            get { return y_title; }
            set
            {
                y_title = value;
                NotifyOfPropertyChange(() => Y_Title);
            }
        }

        private string x_title = "Month";

        public string X_Title
        {
            get { return x_title; }
            set
            {
                x_title = value;
                NotifyOfPropertyChange(() => X_Title);
            }
        }

        public async Task Hours()
        {
            X_Title = "Date";
            Y_Title = "Hours";
            //CurrentItem = "Hours";
            await LoadHoursChart();
        }

        public async Task MonthlyTotals()
        {

            Y_Title = "Totals";
            X_Title = "Month";
            //CurrentItem = "Montly Totals";
            await LoadMonthlyTotals();
        }

        public async Task WeeklyTotals()
        {
            X_Title = "Week";
            Y_Title = "Totals";
            //CurrentItem = "Weekly Totals";
            await LoadWeeklyTotals();
        }

        public async Task JobTotals()
        {
            X_Title = "Jobs";
            Y_Title = "Totals";
            //CurrentItem = "Job Totals";
            await LoadJobTotals();
        }

        public async Task DailyTotals()
        {
            X_Title = "Date";
            Y_Title = "Totals";
            //CurrentItem = "Daily Totals";
            await LoadDailyTotals();
        }

        public async Task LocationTotals()
        {
            X_Title = "Location";
            Y_Title = "Totals";
            //CurrentItem = "Location Totals";
            await LoadLocationTotals();
        }


        public void Clear()
        {
            SelectedUsers.Clear();
            if(SeriesCollection != null)
            {
                SeriesCollection.Clear();
            }
            if(Labels != null)
            {
                Labels.Clear();
            }

            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
        }

        public void RemoveUser()
        {
            SelectedUsers.Remove(SelectedUserListBox);
        }

        public void AddUser()
        {
            if(SelectedUser.FirstName.Contains("Company"))
            {
                SelectedUsers.Clear();
                foreach(var user in Users)
                {
                    if(!user.FirstName.Contains("Company"))
                    {
                        SelectedUsers.Add(user);
                    }
                }
            }
            else
            {
                SelectedUsers.Add(SelectedUser);
            }

        }

        public async Task Go()
        {

            if (SelectedStat.Contains("Hours"))
            {
                await Hours();
            }
            else if (SelectedStat.Contains("Monthly"))
            {
                await MonthlyTotals();
            }
            else if (SelectedStat.Contains("Weekly"))
            {
                await WeeklyTotals();
            }
            else if(SelectedStat.Contains("Daily"))
            {
                await DailyTotals();
            }
            else if(SelectedStat.Contains("Location"))
            {
               await LocationTotals();
            }
            else if(SelectedStat.Contains("Job"))
            {
               await JobTotals();
            }
            else
            {
                return;
            }

        }

        public void Home()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }

    }
}
