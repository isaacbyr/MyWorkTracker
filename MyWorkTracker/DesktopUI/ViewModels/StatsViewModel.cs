using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using LiveCharts;
using LiveCharts.Wpf;

namespace DesktopUI.ViewModels
{
    public class StatsViewModel: Screen
    {
        private readonly IChartEndpoint _chartEndpoint;
        private readonly IEventAggregator _events;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<decimal, string> Formatter { get; set; }

        public StatsViewModel(IChartEndpoint chartEndpoint, IEventAggregator events)
        {
            _chartEndpoint = chartEndpoint;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadMonthlyTotalsChart();
        }

        public async Task LoadMonthlyTotalsChart()
        {
            var data = await _chartEndpoint.LoadMonthlyChartData();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Month",
                    Values =  new ChartValues<decimal>(data.Select(entry => entry.Total)),
                    Fill = System.Windows.Media.Brushes.CadetBlue
                }
            };

            Labels = new string[data.Count];
            int index = 0;
            foreach (string month in data.Select(entry => entry.Month))
            {
                Labels[index] = month;
                index += 1;
            }

            Formatter = value => value.ToString("N");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);

        }

        public async Task LoadWeeklyTotalsChart()
        {
            var data = await _chartEndpoint.LoadWeeklyChartData();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Week",
                    Values =  new ChartValues<decimal>(data.Select(entry => entry.Total))
                }
            };

            Labels = new string[data.Count];
            int index = 0;
            foreach (string week in data.Select(entry => entry.Week))
            {
                Labels[index] = week;
                index += 1;
            }

            Formatter = value => value.ToString("N");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);
        }

        public async Task LoadJobTotals()
        {
            var data = await _chartEndpoint.LoadJobTotalsChartData();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Job",
                    Values =  new ChartValues<decimal>(data.Select(entry => entry.Total))
                }
            };

            Labels = new string[data.Count];
            int index = 0;
            foreach (string job in data.Select(entry => entry.Job))
            {
                Labels[index] = job;
                index += 1;
            }

            Formatter = value => value.ToString("N");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);
        }

        public async Task LoadHoursChart()
        {
            var data = await _chartEndpoint.LoadHoursChartData();

            decimal average = data.Sum(entry => entry.Hours) / data.Count;

            ChartValues<decimal> averageValues = new ChartValues<decimal>();

            for(int i = 0; i < data.Count; i++)
            {
                averageValues.Add(average);
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Hours",
                    Values =  new ChartValues<decimal>(data.Select(entry => entry.Hours)),
                    Fill = System.Windows.Media.Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Average",
                    Values = averageValues,
                    Fill = System.Windows.Media.Brushes.Transparent

                }
            };

            Labels = new string[data.Count];
            int index = 0;
            foreach (DateTime date in data.Select(entry => entry.Date))
            {
                Labels[index] = date.ToString("dd, MMM, yy");
                index += 1;
            }

            Formatter = value => value.ToString("C");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);
        }

        public async Task LoadDailyTotals()
        {
            var data = await _chartEndpoint.LoadDailyChartData();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Day",
                    Values =  new ChartValues<decimal>(data.Select(entry => entry.Total))
                }
            };

            Labels = new string[data.Count];
            int index = 0;
            foreach (DateTime day in data.Select(entry => entry.Date))
            {

                Labels[index] = day.ToString("dd, MMM, yy");
                index += 1;
            }

            Formatter = value => value.ToString("N");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);
        }

        public async Task MonthlyTotals ()
        {
           
            Y_Title = "Totals";
            X_Title = "Month";
            CurrentItem = "Montly Totals";
            await LoadMonthlyTotalsChart();
        }

        public async Task WeeklyTotals()
        { 
            X_Title = "Week";
            Y_Title = "Totals";
            CurrentItem = "Weekly Totals";
            await LoadWeeklyTotalsChart();
        }

        public async Task JobTotals()
        {
            X_Title = "Jobs";
            Y_Title = "Totals";
            CurrentItem = "Job Totals";
            await LoadJobTotals();
        }

        public async Task DailyTotals()
        {
            X_Title = "Date";
            Y_Title = "Totals";
            CurrentItem = "Daily Totals";
            await LoadDailyTotals();
        }

        public async Task LocationTotals()
        {
            X_Title = "Location";
            Y_Title = "Totals";
            CurrentItem = "Location Totals";
            await LoadLocationTotals();
        }

        public async Task LoadLocationTotals()
        {
            var data = await _chartEndpoint.LoadLocationChartData();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Job",
                    Values =  new ChartValues<decimal>(data.Select(entry => entry.Total))
                }
            };

            Labels = new string[data.Count];
            int index = 0;
            foreach (string location in data.Select(entry => entry.Location))
            {
                Labels[index] = location;
                index += 1;
            }

            Formatter = value => value.ToString("N");
            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);
            NotifyOfPropertyChange(() => Formatter);
        }

        public async Task Hours ()
        {
            X_Title = "Date";
            Y_Title = "Hours";
            CurrentItem = "Hours";
            await LoadHoursChart();
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

        private string _currentItem = "Monthly Totals";

        public string CurrentItem
        {
            get { return _currentItem; }
            set 
            { 
                _currentItem = value;
                NotifyOfPropertyChange(() => CurrentItem);
            }
        }


        public void Exit ()
        {
            TryClose();
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    }
}
