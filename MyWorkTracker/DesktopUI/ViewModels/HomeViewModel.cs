using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DesktopUI.ViewModels
{
    public class HomeViewModel: Screen
    {
        private readonly IEventAggregator _events;
        private readonly IApiHelper _apiHelper;
        private readonly ILoggedInUserModel _loggedInUser;
        private readonly IEntryEndpoint _entryEndpoint;

        public HomeViewModel(IEventAggregator events, IApiHelper apiHelper, ILoggedInUserModel loggedInUser, IEntryEndpoint entryEndpoint)
        {
            _events = events;
            _apiHelper = apiHelper;
            _loggedInUser = loggedInUser;
            _entryEndpoint = entryEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            GetCurrentSelectedDate(false, true);
            firstDayOfMonth();
            await LoadTotals();
            NotifyOfPropertyChange(() => IsToday);
        }

        public int MonthIndex { get; set; } = DateTime.Now.Month;
        public int YearIndex { get; set; } = DateTime.Now.Year;

        public int DaysInMonth(int value = 0, bool prevYear = false, bool defaultLoad = false)
        {
            DateTime selectedMonth;
            
            if(prevYear == true)
            {
                DateTime.TryParseExact(CurrentSelectedDate, "MMMM, yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedMonth);
                return DateTime.DaysInMonth(DateTime.Now.Year - 1, 12);
            }
            else
            {
                DateTime.TryParseExact(CurrentSelectedDate, "MMMM, yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedMonth);
                int days =  DateTime.DaysInMonth(selectedMonth.Year, selectedMonth.Month + value);
                return days;
            }
            
        }

        public async Task CurrentDateHeader()
        {
            CurrentSelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM, yy");
            MonthIndex = DateTime.Now.Month;
            YearIndex = DateTime.Now.Year;
            firstDayOfMonth();
            await LoadTotals();
        }

        public async Task Next()
        {
            MonthIndex += 1;
            GetCurrentSelectedDate(false);
            firstDayOfMonth();
            await LoadTotals();

            NotifyOfPropertyChange(() => One);
            // NotifyOfPropertyChange(() => CurrentSelectedDate);
        }

        public async Task Prev()
        {
            if (MonthIndex != 1)
            {
                MonthIndex -= 1;
            }
                     
            GetCurrentSelectedDate(true, false);
            firstDayOfMonth();
            await LoadTotals();

            NotifyOfPropertyChange(() => One);
            //NotifyOfPropertyChange(() => CurrentSelectedDate);
        }

        public string W_OneTotals
        {
            get
            {
                decimal one;
                Decimal.TryParse(T_One, NumberStyles.Currency, CultureInfo.CurrentCulture, out one);
                decimal two;
                Decimal.TryParse(T_Two, NumberStyles.Currency, CultureInfo.CurrentCulture, out two);
                decimal three;
                Decimal.TryParse(T_Three, NumberStyles.Currency, CultureInfo.CurrentCulture, out three);
                decimal four;
                Decimal.TryParse(T_Four, NumberStyles.Currency, CultureInfo.CurrentCulture, out four);
                decimal five;
                Decimal.TryParse(T_Five, NumberStyles.Currency, CultureInfo.CurrentCulture, out five);
                decimal six;
                Decimal.TryParse(T_Six, NumberStyles.Currency, CultureInfo.CurrentCulture, out six);
                decimal seven;
                Decimal.TryParse(T_Seven, NumberStyles.Currency, CultureInfo.CurrentCulture, out seven);

                return (one + two + three + four + five + six + seven).ToString("C");
            }
        }

        public string W_TwoTotals
        {
            get
            {
                decimal eight;
                Decimal.TryParse(T_Eight, NumberStyles.Currency, CultureInfo.CurrentCulture,  out eight);
                decimal nine;
                Decimal.TryParse(T_Nine, NumberStyles.Currency, CultureInfo.CurrentCulture, out nine);
                decimal ten;
                Decimal.TryParse(T_Ten, NumberStyles.Currency, CultureInfo.CurrentCulture, out ten);
                decimal eleven;
                Decimal.TryParse(T_Eleven, NumberStyles.Currency, CultureInfo.CurrentCulture,  out eleven);
                decimal twelve;
                Decimal.TryParse(T_Twelve, NumberStyles.Currency, CultureInfo.CurrentCulture, out twelve);
                decimal thirteen;
                Decimal.TryParse(T_Thirteen, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirteen);
                decimal fourteen;
                Decimal.TryParse(T_Fourteen, NumberStyles.Currency, CultureInfo.CurrentCulture, out fourteen);

                return (eight + nine + ten + eleven + twelve + thirteen + fourteen).ToString("C");
            }
        }

        public string W_ThreeTotals
        {
            get
            {
                decimal fifteen;
                Decimal.TryParse(T_Fifteen, NumberStyles.Currency, CultureInfo.CurrentCulture, out fifteen);
                decimal sixteen;
                Decimal.TryParse(T_Sixteen, NumberStyles.Currency, CultureInfo.CurrentCulture, out sixteen);
                decimal seventeen;
                Decimal.TryParse(T_Seventeen, NumberStyles.Currency, CultureInfo.CurrentCulture, out seventeen);
                decimal eighteen;
                Decimal.TryParse(T_Eighteen, NumberStyles.Currency, CultureInfo.CurrentCulture, out eighteen);
                decimal nineteen;
                Decimal.TryParse(T_Nineteen, NumberStyles.Currency, CultureInfo.CurrentCulture, out nineteen);
                decimal twenty;
                Decimal.TryParse(T_Twenty, NumberStyles.Currency, CultureInfo.CurrentCulture, out twenty);
                decimal twentyOne;
                Decimal.TryParse(T_TwentyOne, NumberStyles.Currency, CultureInfo.CurrentCulture,  out twentyOne);

                return (fifteen + sixteen + seventeen + eighteen + nineteen + twenty + twentyOne).ToString("C");
            }
        }

        public string W_FourTotals
        {
            get
            {
                decimal twentyTwo;
                Decimal.TryParse(T_TwentyTwo, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentyTwo);
                decimal twentyThree;
                Decimal.TryParse(T_TwentyThree, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentyThree);
                decimal twentyFour;
                Decimal.TryParse(T_TwentyFour, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentyFour);
                decimal twentyFive;
                Decimal.TryParse(T_TwentyFive, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentyFive);
                decimal twentySix;
                Decimal.TryParse(T_TwentySix, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentySix);
                decimal twentySeven;
                Decimal.TryParse(T_TwentySeven, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentySeven);
                decimal twentyEight;
                Decimal.TryParse(T_TwentyEight, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentyEight);

                return (twentyTwo + twentyThree + twentyFour + twentyFive + twentySix + twentySeven + twentyEight).ToString("C");
            }
        }

        public string W_FiveTotals
        {
            get
            {
                decimal twentyNine;
                Decimal.TryParse(T_TwentyNine, NumberStyles.Currency, CultureInfo.CurrentCulture, out twentyNine);
                decimal thirty;
                Decimal.TryParse(T_Thirty, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirty);
                decimal thirtyOne;
                Decimal.TryParse(T_ThirtyOne, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirtyOne);
                decimal thirtyTwo;
                Decimal.TryParse(T_ThirtyTwo, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirtyTwo);
                decimal thirtyThree;
                Decimal.TryParse(T_ThirtyThree, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirtyThree);
                decimal thirtyFour;
                Decimal.TryParse(T_ThirtyFour, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirtyFour);
                decimal thirtyFive;
                Decimal.TryParse(T_ThirtyFive, NumberStyles.Currency, CultureInfo.CurrentCulture, out thirtyFive);

                return (twentyNine + thirty + thirtyOne + thirtyTwo + thirtyThree + thirtyFour + thirtyFive).ToString("C");
            }
        }

        public string MonthTotal
        {
            get
            {
                decimal w1_total;
                Decimal.TryParse(W_OneTotals, NumberStyles.Currency, CultureInfo.CurrentCulture, out w1_total);
                decimal w2_total;
                Decimal.TryParse(W_TwoTotals, NumberStyles.Currency, CultureInfo.CurrentCulture, out w2_total);
                decimal w3_total;
                Decimal.TryParse(W_ThreeTotals, NumberStyles.Currency, CultureInfo.CurrentCulture, out w3_total);
                decimal w4_total;
                Decimal.TryParse(W_FourTotals, NumberStyles.Currency, CultureInfo.CurrentCulture, out w4_total);
                decimal w5_total;
                Decimal.TryParse(W_FiveTotals, NumberStyles.Currency, CultureInfo.CurrentCulture, out w5_total);


                return (w1_total + w2_total + w3_total + w4_total + w5_total).ToString("C");
            }
        }

        public (DateTime, DateTime) LoadFirstAndLastDates()
        {
            int firstValue;
            int.TryParse(One, out firstValue);
            int lastValue;
            int.TryParse(ThirtyFive, out lastValue);

            DateTime selectedDate;
            DateTime.TryParseExact(CurrentSelectedDate, "MMMM, yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate);
            DateTime firstDate;
            DateTime lastDate;

            if (firstValue >= 26 && selectedDate.Month == 1)
            {
                firstDate = new DateTime(selectedDate.Year - 1, 12, firstValue);
            }

            else if (firstValue >= 26 && selectedDate.Month != 1)
            {
                firstDate = new DateTime(selectedDate.Year, selectedDate.Month - 1, firstValue);
            }
            else
            {
                firstDate = new DateTime(selectedDate.Year, selectedDate.Month, firstValue);
            }

            if(lastValue <= 6 && selectedDate.Month == 12)
            {
                lastDate = new DateTime(selectedDate.Year+1, 1, lastValue);
            }
            else if (lastValue <= 6 && selectedDate.Month != 12)
            {
                lastDate = new DateTime(selectedDate.Year, selectedDate.Month + 1, lastValue);

            }
            else
            {
                lastDate = new DateTime(selectedDate.Year, selectedDate.Month, lastValue);
            }
            return (firstDate, lastDate) ;
        }

        public string convertDates (string calendarLoc, int counter)
        {
            DateTime selectedDate;
            DateTime.TryParseExact(CurrentSelectedDate, "MMMM, yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate);

            int convDate;
            int.TryParse(calendarLoc, out convDate);

            if (counter < 7 && convDate >= 23 && selectedDate.Month != 1)
            {
                // last month, current year
                return new DateTime(selectedDate.Year, selectedDate.Month - 1, convDate).ToString("dd-MM-yyyy");
            }
            else if (counter < 7 && convDate >= 23 && selectedDate.Month == 1 )
            {
                // last month, last year
                return new DateTime(selectedDate.Year - 1, 12,convDate).ToString("dd-MM-yyyy");
            }
            else if (counter >= 23 && convDate <= 7 && selectedDate.Month != 12)
            {
                // next month, current year
                return new DateTime(selectedDate.Year, selectedDate.Month + 1, convDate).ToString("dd-MM-yyyy");
            }
            else if (counter >= 23 && convDate <= 7 && selectedDate.Month == 12)
            {
                // next month, next year
                return new DateTime(selectedDate.Year + 1, 1, convDate).ToString("dd-MM-yyyy");
            }
            else 
            {
                // this month
                return new DateTime(selectedDate.Year, selectedDate.Month, convDate).ToString("dd-MM-yyyy");
            }

        }

        public async Task LoadTotals()
        {

            int counter = 1;

            Dictionary<string, decimal> items = new Dictionary<string, decimal>();

            DateTime firstDate, lastDate;

            (firstDate, lastDate) = LoadFirstAndLastDates();

            ResetTotals();
            var result = await _entryEndpoint.LoadEntriesBetweenDates(firstDate, lastDate);

            if (result != null)
            {
                
                foreach(var entry in result)
                {
                    items.Add(entry.JobDate.ToString("dd-MM-yyyy"), entry.Total);
                }

                string date;

                date = convertDates(One, counter);
                counter += 1;
                if(items.ContainsKey(date))
                {
                    T_One = items[date].ToString("C");
                }

                date = convertDates(Two, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Two = items[date].ToString("C");
                }

                date = convertDates(Three, counter);
                counter += 1; 
                if (items.ContainsKey(date))
                {
                    T_Three = items[date].ToString("C");
                }

                date = convertDates(Four, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Four = items[date].ToString("C");
                }

                date = convertDates(Five, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Five = items[date].ToString("C");
                }

                date = convertDates(Six, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Six = items[date].ToString("C");
                }

                date = convertDates(Seven, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Seven = items[date].ToString("C");
                }

                date = convertDates(Eight, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Eight = items[date].ToString("C");
                }

                date = convertDates(Nine, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Nine = items[date].ToString("C");
                }

                date = convertDates(Ten, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Ten = items[date].ToString("C");
                }

                date = convertDates(Eleven, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Eleven = items[date].ToString("C");
                }

                date = convertDates(Twelve, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Twelve = items[date].ToString("C");
                }

                date = convertDates(Thirteen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Thirteen = items[date].ToString("C");
                }

                date = convertDates(Fourteen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Fourteen = items[date].ToString("C");
                }

                date = convertDates(Fifteen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Fifteen = items[date].ToString("C");
                }

                date = convertDates(Sixteen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Sixteen = items[date].ToString("C");
                }

                date = convertDates(Seventeen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Seventeen = items[date].ToString("C");
                }

                date = convertDates(Eighteen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Eighteen = items[date].ToString("C");
                }

                date = convertDates(Nineteen, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Nineteen = items[date].ToString("C");
                }

                date = convertDates(Twenty, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Twenty = items[date].ToString("C");
                }

                date = convertDates(TwentyOne, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyOne = items[date].ToString("C");
                }

                date = convertDates(TwentyTwo, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyTwo = items[date].ToString("C");
                }

                date = convertDates(TwentyThree, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyThree = items[date].ToString("C");
                }

                date = convertDates(TwentyFour, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyFour = items[date].ToString("C");
                }

                date = convertDates(TwentyFive, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyFive = items[date].ToString("C");
                }

                date = convertDates(TwentySix, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentySix = items[date].ToString("C");
                }

                date = convertDates(TwentySeven, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentySeven = items["TwentySeven"].ToString("C");
                }

                date = convertDates(TwentyEight, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyEight = items[date].ToString("C");
                }

                date = convertDates(TwentyNine, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_TwentyNine = items[date].ToString("C");
                }

                date = convertDates(Thirty, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_Thirty = items[date].ToString("C");
                }

                date = convertDates(ThirtyOne, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_ThirtyOne = items[date].ToString("C");
                }

                date = convertDates(ThirtyTwo, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_ThirtyTwo = items[date].ToString("C");
                }

                date = convertDates(ThirtyThree, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_ThirtyThree = items[date].ToString("C");
                }

                date = convertDates(ThirtyFour, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_ThirtyFour = items[date].ToString("C");
                }

                date = convertDates(ThirtyFive, counter);
                counter += 1;
                if (items.ContainsKey(date))
                {
                    T_ThirtyFive = items[date].ToString("C");
                }
            }
            else
            {
                ResetTotals();
            }

            NotifyOfPropertyChange(() => W_OneTotals);
            NotifyOfPropertyChange(() => W_TwoTotals);
            NotifyOfPropertyChange(() => W_ThreeTotals);
            NotifyOfPropertyChange(() => W_FourTotals);
            NotifyOfPropertyChange(() => W_FiveTotals);
            NotifyOfPropertyChange(() => MonthTotal);

        }

        public void ResetTotals()
        {
            T_One = "";
            T_Two = "";
            T_Three = "";
            T_Four = "";
            T_Five = "";
            T_Six = "";
            T_Seven = "";
            T_Eight = "";
            T_Nine = "";
            T_Ten = "";
            T_Eleven = "";
            T_Twelve = "";
            T_Thirteen = "";
            T_Fourteen = "";
            T_Fifteen = "";
            T_Sixteen = "";
            T_Seventeen = "";
            T_Eighteen = "";
            T_Nineteen = "";
            T_Twenty = "";
            T_TwentyOne = "";
            T_TwentyTwo = "";
            T_TwentyThree = "";
            T_TwentyFour = "";
            T_TwentyFive = "";
            T_TwentySix = "";
            T_TwentySeven = "";
            T_TwentyEight = "";
            T_TwentyNine = "";
            T_Thirty = "";
            T_ThirtyOne = "";
            T_ThirtyTwo = "";
            T_ThirtyThree = "";
            T_ThirtyFour = "";
            T_ThirtyFive = "";
        }

        private string _t_one;

        public string T_One
        {
            get { return _t_one; }
            set 
            { 
                _t_one = value;
                NotifyOfPropertyChange(() => T_One);

            }
        }

        private string _t_two;

        public string T_Two
        {
            get { return _t_two; }
            set 
            { 
                _t_two = value;
                NotifyOfPropertyChange(() => T_Two);
            }
        }

        private string _t_three;

        public string T_Three
        {
            get { return _t_three; }
            set 
            { 
                _t_three = value;
                NotifyOfPropertyChange(() => T_Three);
            }
        }

        private string _t_four;

        public string T_Four
        {
            get { return _t_four; }
            set 
            { 
                _t_four = value;
                NotifyOfPropertyChange(() => T_Four);
            }
        }

        private string _t_five;

        public string T_Five
        {
            get { return _t_five; }
            set 
            { 
                _t_five = value;
                NotifyOfPropertyChange(() => T_Five);
            }
        }

        private string _t_six;

        public string T_Six
        {
            get { return _t_six; }
            set 
            { 
                _t_six = value;
                NotifyOfPropertyChange(() => T_Six);
            }
        }

        private string _t_seven;

        public string T_Seven
        {
            get { return _t_seven; }
            set 
            { 
                _t_seven = value;
                NotifyOfPropertyChange(() => T_Seven);
            }
        }

        private string _t_eight;

        public string T_Eight
        {
            get { return _t_eight; }
            set 
            { 
                _t_eight = value;
                NotifyOfPropertyChange(() => T_Eight);
            }
        }

        private string _t_nine;

        public string T_Nine
        {
            get { return _t_nine; }
            set
            {
                _t_nine = value;
                NotifyOfPropertyChange(() => T_Nine);
            }
        }

        private string _t_ten;

        public string T_Ten
        {
            get { return _t_ten; }
            set
            { 
                _t_ten = value;
                NotifyOfPropertyChange(() => T_Ten);
            }
        }

        private string _t_eleven;

        public string T_Eleven
        {
            get { return _t_eleven; }
            set 
            { 
                _t_eleven = value;
                NotifyOfPropertyChange(() => T_Eleven);
            }
        }

        private string _t_twelve;

        public string T_Twelve
        {
            get { return _t_twelve; }
            set 
            { 
                _t_twelve = value;
                NotifyOfPropertyChange(() => T_Twelve);
            }
        }

        private string _t_thirteen;

        public string T_Thirteen
        {
            get { return _t_thirteen; }
            set 
            { 
                _t_thirteen = value;
                NotifyOfPropertyChange(() => T_Thirteen);
            }
        }

        private string _t_fourteen;

        public string T_Fourteen
        {
            get { return _t_fourteen; }
            set 
            { 
                _t_fourteen = value;
                NotifyOfPropertyChange(() => T_Fourteen);
            }
        }

        private string _t_fifteen;

        public string T_Fifteen
        {
            get { return _t_fifteen; }
            set 
            { 
                _t_fifteen = value;
                NotifyOfPropertyChange(() => T_Fifteen);
            }
        }

        private string _t_sixteen;

        public string T_Sixteen
        {
            get { return _t_sixteen; }
            set 
            { 
                _t_sixteen = value;
                NotifyOfPropertyChange(() => T_Sixteen);
            }
        }

        private string _t_seventeen;

        public string T_Seventeen
        {
            get { return _t_seventeen; }
            set 
            { 
                _t_seventeen = value;
                NotifyOfPropertyChange(() => T_Seventeen);
            }
        }

        private string _t_eighteen;

        public string T_Eighteen
        {
            get { return _t_eighteen; }
            set 
            { 
                _t_eighteen = value;
                NotifyOfPropertyChange(() => T_Eighteen);
            }
        }

        private string _t_nineteen;

        public string T_Nineteen
        {
            get { return _t_nineteen; }
            set 
            { 
                _t_nineteen = value;
                NotifyOfPropertyChange(() => T_Nineteen);
            }
        }

        private string _t_twenty;

        public string T_Twenty
        {
            get { return _t_twenty; }
            set 
            { 
                _t_twenty = value;
                NotifyOfPropertyChange(() => T_Twenty);
            }
        }

        private string _t_twentyOne;

        public string T_TwentyOne
        {
            get { return _t_twentyOne; }
            set 
            { 
                _t_twentyOne = value;
                NotifyOfPropertyChange(() => T_TwentyOne);
            }
        }

        private string _t_twentyTwo;

        public string T_TwentyTwo
        {
            get { return _t_twentyTwo; }
            set 
            {
                _t_twentyTwo = value;
                NotifyOfPropertyChange(() => T_TwentyTwo);
            }
        }

        private string _t_twentyThree;

        public string T_TwentyThree
        {
            get { return _t_twentyThree; }
            set 
            { 
                _t_twentyThree = value;
                NotifyOfPropertyChange(() => T_TwentyThree);
            }
        }

        private string _t_twentyFour;

        public string T_TwentyFour
        {
            get { return _t_twentyFour; }
            set 
            { 
                _t_twentyFour = value;
                NotifyOfPropertyChange(() => T_TwentyFour);
            }
        }

        private string _t_twentyFive;

        public string T_TwentyFive
        {
            get { return _t_twentyFive; }
            set 
            { 
                _t_twentyFive = value;
                NotifyOfPropertyChange(() => T_TwentyFive);
            }
        }

        private string _t_twentySix;

        public string T_TwentySix
        {
            get { return _t_twentySix; }
            set 
            { 
                _t_twentySix = value;
                NotifyOfPropertyChange(() => T_TwentySix);
            }
        }

        private string _t_twentySeven;

        public string T_TwentySeven
        {
            get { return _t_twentySeven; }
            set 
            { 
                _t_twentySeven = value;
                NotifyOfPropertyChange(() => T_TwentySeven);
            }
        }

        private string _t_twentyEight;

        public string T_TwentyEight
        {
            get { return _t_twentyEight; }
            set 
            { 
                _t_twentyEight = value;
                NotifyOfPropertyChange(() => T_TwentyEight);
            }
        }

        private string _t_twentyNine;

        public string T_TwentyNine
        {
            get { return _t_twentyNine; }
            set 
            { 
                _t_twentyNine = value;
                NotifyOfPropertyChange(() => T_TwentyNine);
            }
        }

        private string _t_thirty;

        public string T_Thirty
        {
            get { return _t_thirty; }
            set 
            { 
                _t_thirty = value;
                NotifyOfPropertyChange(() => T_Thirty);
            }
        }

        private string _t_thirtyOne;

        public string T_ThirtyOne
        {
            get { return _t_thirtyOne; }
            set 
            {
                _t_thirtyOne = value;
                NotifyOfPropertyChange(() => T_ThirtyOne);
            }
        }

        private string _t_thirtyTwo;

        public string T_ThirtyTwo
        {
            get { return _t_thirtyTwo; }
            set 
            { 
                _t_thirtyTwo = value;
                NotifyOfPropertyChange(() => T_ThirtyTwo);
            }
        }

        private string _t_thirtyThree;

        public string T_ThirtyThree
        {
            get { return _t_thirtyThree; }
            set 
            { 
                _t_thirtyThree = value;
                NotifyOfPropertyChange(() => T_ThirtyThree);
            }
        }

        private string _t_thirtyFour;

        public string T_ThirtyFour
        {
            get { return _t_thirtyFour; }
            set 
            { 
                _t_thirtyFour = value;
                NotifyOfPropertyChange(() => T_ThirtyFour);
            }
        }

        private string _t_thirtyFive;

        public string T_ThirtyFive
        {
            get { return _t_thirtyFive; }
            set 
            { 
                _t_thirtyFive = value;
                NotifyOfPropertyChange(() => T_ThirtyFive);
            }
        }


        public bool IsToday
        {
            get 
            {

                if (Today.Day.ToString("") == "22")
                {
                    return true;
                }
                return false;
            }
            
        }

        public void ViewStats ()
        {
            _events.PublishOnUIThread(new OpenStatsView());
        }

        //public void New()
        //{
        //    _events.PublishOnUIThread(new CreateNewEvent());
        //}

        public DateTime Today
        {
            get
            {
                //NotifyOfPropertyChange(() => IsToday);
                return DateTime.Today;

            }
        }

        private string _currDate = DateTime.Now.ToString("dddd, MMM d yyyy").ToUpper();

        public string CurrDate
        {
            get { return _currDate; }
            set 
            { 
                _currDate = value;
                NotifyOfPropertyChange(() => CurrDate);
                NotifyOfPropertyChange(() => CurrentSelectedDate);
            }
        }

        public void firstDayOfMonth ()
        {
            DateTime selectedDate;
            DateTime.TryParseExact(CurrentSelectedDate, "MMMM, yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate);

            int daysInMonth;

            if (selectedDate.Month == 1)
            {
                daysInMonth = DaysInMonth(0, true);
            }
            else
            {
                daysInMonth = DaysInMonth(-1, false);
            }
            DayOfWeek FirstDay = new DateTime(selectedDate.Year, selectedDate.Month, 1).DayOfWeek;
                
            if(FirstDay.ToString() == "Monday")
            {
                One = "1";
            }
            else if (FirstDay.ToString() == "Tuesday")
            {
                if(daysInMonth == 28)
                {
                    One = "28";
                }
                else if (daysInMonth == 30)
                {
                    One = "30";
                }
                else if (daysInMonth == 31)
                {
                    One = "31";
                }  
            }
            else if (FirstDay.ToString() == "Wednesday")
            {
                if (daysInMonth == 28)
                {
                    One = "27";
                }
                else if (daysInMonth == 30)
                {
                    One = "29";
                }
                else if (daysInMonth == 31)
                {
                    One = "30";
                }
            }
            else if (FirstDay.ToString() == "Thursday")
            {
                if (daysInMonth == 28)
                {
                    One = "26";
                }
                else if (daysInMonth == 30)
                {
                    One = "28";
                }
                else if (daysInMonth == 31)
                {
                    One = "29";
                }
            }
            else if(FirstDay.ToString() == "Friday")
            {
                if (daysInMonth == 28)
                {
                    One = "25";
                }
                else if (daysInMonth == 30)
                {
                    One = "27";
                }
                else if (daysInMonth == 31)
                {
                    One = "28";
                }
            }
            else if (FirstDay.ToString() == "Saturday")
            {
                if (daysInMonth == 28)
                {
                    One = "24";
                }
                else if (daysInMonth == 30)
                {
                    One = "26";
                }
                else if (daysInMonth == 31)
                {
                    One = "27";
                }
            }
            else if (FirstDay.ToString() == "Sunday")
            {
                if (daysInMonth == 28)
                {
                    One = "23";
                }
                else if (daysInMonth == 30)
                {
                    One = "25";
                }
                else if (daysInMonth == 31)
                {
                    One = "26";
                }
            }
        }

        public void Add_New(RoutedEventArgs e)
        {
            var content = (e.Source as Button).Content.ToString();
            var itemLocation = (e.Source as Button).Name.ToString();

            DateTime selectedMonth;
            DateTime.TryParseExact(CurrentSelectedDate, "MMMM, yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedMonth);
            bool prevMonth = IsPreviousMonth(content, itemLocation);
            bool nextMonth = IsNextMonth(content, itemLocation);

            _events.PublishOnUIThread(new CreateNewEvent(content, prevMonth, nextMonth, selectedMonth, itemLocation));
        }

        public void GetCurrentSelectedDate(bool prev, bool defaultLoad = false)
        {
            int numDays = DaysInMonth();

            if (defaultLoad == true)
            {
                int daysInMonth = DaysInMonth(0, false, true);
                CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day < daysInMonth ? DateTime.Now.Day : daysInMonth).ToString("MMMM, yy");
                //CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day).ToString("MMMM, yy");
            } 

            //else if (MonthIndex == 12 && prev == false)
            //{
            //    MonthIndex = 1;
            //    YearIndex += 1;
            //    CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day < numDays ? DateTime.Now.Day : numDays).ToString("MMMM, yy");

                //}
            else if (MonthIndex == 1 && prev == true)
            {
               MonthIndex = 12;
               YearIndex -=1;
               CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day < numDays ? DateTime.Now.Day : numDays).ToString("MMMM, yy");

            }
            else if (MonthIndex == 13)
            {
                MonthIndex = 1;
                YearIndex += 1;
                CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day < numDays ? DateTime.Now.Day : numDays).ToString("MMMM, yy");

            }
            else if (MonthIndex == -13)
            {
                MonthIndex = 12;
                YearIndex -= 1;

                CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day < numDays ? DateTime.Now.Day : numDays).ToString("MMMM, yy");
            }
            else
            {
                CurrentSelectedDate = new DateTime(YearIndex, MonthIndex, DateTime.Now.Day < numDays ? DateTime.Now.Day : numDays).ToString("MMMM, yy");
            }
        }

        private string _currentSelectedDate = DateTime.Now.ToString("MMMM, yy");

        public string CurrentSelectedDate
        {
            get { return _currentSelectedDate; }
            set 
            { 
                _currentSelectedDate = value;
                NotifyOfPropertyChange(() => CurrentSelectedDate);
            }
        }

        public bool IsPreviousMonth(string content, string buttonName)
        {
            int value;
            int.TryParse(content, out value);

            List<string> buttonContents = new List<string>() 
            { "One", "Two", "Three", "Four", "Five", "Six", "Seven" };

            bool inList = buttonContents.Any(s => s.Equals(buttonName));

            if (inList && value >= 23)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNextMonth(string content, string buttonName)
        {
            int value;
            int.TryParse(content, out value);

            List<string> buttonContents = new List<string>() 
            { "TwentyNine", "Thirty", "ThirtyOne", "ThirtyTwo", "ThirtyThree", "ThirtyFour", "ThirtyFive" };

            bool inList = buttonContents.Any(s => s.Equals(buttonName));

            if(inList && value <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private string _one;

        public string One
        {
            get { return _one; }
            set 
            { 
                _one = value;
                NotifyOfPropertyChange(() => One);
                NotifyOfPropertyChange(() => Two);
                NotifyOfPropertyChange(() => Three);
                NotifyOfPropertyChange(() => Four);
                NotifyOfPropertyChange(() => Five);
                NotifyOfPropertyChange(() => Six);
                NotifyOfPropertyChange(() => Seven);
                NotifyOfPropertyChange(() => Eight);
                NotifyOfPropertyChange(() => Nine);
                NotifyOfPropertyChange(() => Ten);
                NotifyOfPropertyChange(() => Eleven);
                NotifyOfPropertyChange(() => Twelve);
                NotifyOfPropertyChange(() => Thirteen);
                NotifyOfPropertyChange(() => Fourteen);
                NotifyOfPropertyChange(() => Fifteen);
                NotifyOfPropertyChange(() => Sixteen);
                NotifyOfPropertyChange(() => Seventeen);
                NotifyOfPropertyChange(() => Eighteen);
                NotifyOfPropertyChange(() => Nineteen);
                NotifyOfPropertyChange(() => Twenty);
                NotifyOfPropertyChange(() => TwentyOne);
                NotifyOfPropertyChange(() => TwentyTwo);
                NotifyOfPropertyChange(() => TwentyThree);
                NotifyOfPropertyChange(() => TwentyFour);
                NotifyOfPropertyChange(() => TwentyFive);
                NotifyOfPropertyChange(() => TwentySix);
                NotifyOfPropertyChange(() => TwentySeven);
                NotifyOfPropertyChange(() => TwentyEight);
                NotifyOfPropertyChange(() => TwentyNine);
                NotifyOfPropertyChange(() => Thirty);
                NotifyOfPropertyChange(() => ThirtyOne);
                NotifyOfPropertyChange(() => ThirtyTwo);
                NotifyOfPropertyChange(() => ThirtyThree);
                NotifyOfPropertyChange(() => ThirtyFour);
                NotifyOfPropertyChange(() => ThirtyFive);
                
            }
        }

        public string GetDayOfMonth(string prevDay, int index = 0)
        {
            int value;
            int.TryParse(prevDay, out value);
            int numDays;

            if (MonthIndex == 1)
            {
                numDays = DaysInMonth(index, true);
            }
            else
            {
                numDays = DaysInMonth(index);
            }
            if (value != numDays)
            {
                return (value + 1).ToString();
            }
            else
            {
                return "1";
            }

        }

        public string Two
        {
            get
            {
                int index = 0;
                int one;
                int.TryParse(One, out one);
                if(one >= 23 )
                {
                    index = -1;
                }
                return GetDayOfMonth(One, index);
            }
        }

        public string Three
        {
            get 
            {
                int index = 0;
                int two;
                int.TryParse(Two, out two);
                if(two >= 23)
                {
                    index = -1;
                }
                return GetDayOfMonth(Two, index);
            }

        }

        public string Four
        {
            get 
            {
                int index = 0;
                int three;
                int.TryParse(Three, out three);
                if (three >= 23)
                {
                    index = -1;
                }
                return GetDayOfMonth(Three, index);
            }

        }

        public string Five
        {
            get
            {
                int index = 0;
                int four;
                int.TryParse(Four, out four);
                if(four >= 23)
                {
                    index = -1;
                }
                return GetDayOfMonth(Four, index);
            }
        }

        public string Six
        {
           get
            {
                int index = 0;
                int five;
                int.TryParse(Five, out five);
                if(five >= 23)
                {
                    index = -1;
                }
                return GetDayOfMonth(Five, index);
            }
        }

        public string Seven
        {
            get
            {
                return GetDayOfMonth(Six);
            }
        }

        public string Eight
        {
            get
            {
                return GetDayOfMonth(Seven);
            }
        }

        public string Nine
        {
            get
            {
                return GetDayOfMonth(Eight);
            }
        }

        public string Ten
        {
            get
            {
                return GetDayOfMonth(Nine);

            }
        }

        public string Eleven
        {
            get
            {
                return GetDayOfMonth(Ten);
            }
        }

        public string Twelve
        {
            get
            {
                return GetDayOfMonth(Eleven);
            }
        }

        public string Thirteen
        {
            get
            {
                return GetDayOfMonth(Twelve);
            }
        }

        public string Fourteen
        {
            get
            {
                return GetDayOfMonth(Thirteen);
            }
        }

        public string Fifteen
        {
            get
            {
                return GetDayOfMonth(Fourteen);
            }
        }

        public string Sixteen
        {
            get
            {
                return GetDayOfMonth(Fifteen);
            }
        }

        public string Seventeen
        {
            get
            {
                return GetDayOfMonth(Sixteen);
            }
        }

        public string Eighteen
        {
            get
            {
                return GetDayOfMonth(Seventeen);
            }
        }

        public string Nineteen
        {
            get
            {
                return GetDayOfMonth(Eighteen);
            }
        }

        public string Twenty
        {
            get
            {
                return GetDayOfMonth(Nineteen);
            }
        }

        public string TwentyOne
        {
            get
            {
                return GetDayOfMonth(Twenty);
            }
        }

        public string TwentyTwo
        {
            get
            { 
                return GetDayOfMonth(TwentyOne);
            }
        }

        public string TwentyThree
        {
            get
            {
                return GetDayOfMonth(TwentyTwo);

            }
        }

        public string TwentyFour
        {
            get
            {
                return GetDayOfMonth(TwentyThree);

            }
        }

        public string TwentyFive
        {
            get
            {
                return GetDayOfMonth(TwentyFour);

            }
        }

        public string TwentySix
        {
            get
            {
                return GetDayOfMonth(TwentyFive);
            }
        }

        public string TwentySeven
        {
            get
            {
                return GetDayOfMonth(TwentySix);
            }
        }

        public string TwentyEight
        {
            get
            {
                return GetDayOfMonth(TwentySeven);
            }
        }

        public string TwentyNine
        {
            get
            {
                return GetDayOfMonth(TwentyEight);

            }
        }

        public string Thirty
        {
            get
            {
                return GetDayOfMonth(TwentyNine);

            }
        }

        public string ThirtyOne
        {
            get
            {
                return GetDayOfMonth(Thirty);
            }
        }

        public string ThirtyTwo
        {
            get
            {
                return GetDayOfMonth(ThirtyOne);
            }

        }

        public string ThirtyThree
        {
            get
            {
                return GetDayOfMonth(ThirtyTwo);
            }
        }

        public string ThirtyFour
        {
            get
            {
                return GetDayOfMonth(ThirtyThree);

            }
        }

        public string ThirtyFive
        {
            get
            {
                return GetDayOfMonth(ThirtyFour);
            }
        }

        
        public void Logout()
        {
            _apiHelper.Logout();
            _loggedInUser.ResetUser();
            _events.PublishOnUIThread(new LogOffEvent());   
        }

        public void Exit()
        {
            _events.PublishOnUIThread(new ExitAppEvent());
        }

        
    }
}
