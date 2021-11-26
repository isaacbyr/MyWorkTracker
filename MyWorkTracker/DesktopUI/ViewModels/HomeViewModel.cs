using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using DesktopUI.Views;
using System;
using System.Collections.Generic;
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

        public HomeViewModel(IEventAggregator events, IApiHelper apiHelper, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _apiHelper = apiHelper;
            _loggedInUser = loggedInUser;
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            firstDayOfMonth();
            NotifyOfPropertyChange(() => IsToday);
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


        public void New()
        {
            _events.PublishOnUIThread(new CreateNewEvent());
        }

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
            }
        }

        public void firstDayOfMonth ()
        {
            
            DayOfWeek FirstDay = new DateTime(Today.Year, Today.Month, 1).DayOfWeek;
                
            if(FirstDay.ToString() == "Monday")
            {
                One = "1";
            }
            else if (FirstDay.ToString() == "Tuesday")
            {
                One = "31";
            }
            else if (FirstDay.ToString() == "Wednesday")
            {
                One = "30";
            }
            else if (FirstDay.ToString() == "Thursday")
            {
                One = "29";
            }
            else if(FirstDay.ToString() == "Friday")
            {
                One = "28";
            }
            else if (FirstDay.ToString() == "Saturday")
            {
                One = "27";
            }
            else if (FirstDay.ToString() == "Sunday")
            {
                One = "26";
            }
        }

        public void Add_New(RoutedEventArgs e)
        {
            var content = (e.Source as Button).Content.ToString();
            _events.PublishOnUIThread(new CreateNewEvent(content));
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

        public string Two
        {
            get
            {
                int oneVal;
                int.TryParse(One, out oneVal);
                if (oneVal != 31)
                {
                    return (oneVal + 1).ToString();
                } 
                else
                {
                    return "1";
                }

            }
        }

        public string Three
        {
            get 
            {
                int twoVal;
                int.TryParse(Two, out twoVal);
                if(twoVal != 31)
                {
                    return (twoVal + 1).ToString();
                }
                else
                {
                    return "1";
                }
                
            }
            
        }

        public string Four
        {
            get 
            {
                int threeVal;
                int.TryParse(Three, out threeVal);
                if (threeVal != 31)
                {
                    return (threeVal + 1).ToString();
                }
                else
                {
                    return "1";
                }
            }
            
        }

        public string Five
        {
            get
            {
                int fourVal;
                int.TryParse(Four, out fourVal);
                if (fourVal != 31)
                {
                    return (fourVal + 1).ToString();
                }
                else
                {
                    return "1";
                }
            }
        }

        public string Six
        {
           get
            {
                int fiveVal;
                int.TryParse(Five, out fiveVal);
                if (fiveVal != 31)
                {
                    return (fiveVal + 1).ToString();
                }
                else
                {
                    return "1";
                }
            }
        }

        public string Seven
        {
            get
            {
                int sixVal;
                int.TryParse(Six, out sixVal);
                if (sixVal != 31)
                {
                    return (sixVal + 1).ToString();
                }
                else
                {
                    return "1";
                }
            }
        }

        public string Eight
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 1).ToString();
            }
        }

        public string Nine
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 2).ToString();
            }
        }

        public string Ten
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 3).ToString();
            }
        }

        public string Eleven
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 4).ToString();
            }
        }

        public string Twelve
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 5).ToString();
            }
        }

        public string Thirteen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 6).ToString();
            }
        }

        public string Fourteen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 7).ToString();
            }
        }

        public string Fifteen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 8).ToString();
            }
        }

        public string Sixteen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 9).ToString();
            }
        }

        public string Seventeen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 10).ToString();
            }
        }

        public string Eighteen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 11).ToString();
            }
        }

        public string Nineteen
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 12).ToString();
            }
        }

        public string Twenty
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 13).ToString();
            }
        }

        public string TwentyOne
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 14).ToString();
            }
        }

        public string TwentyTwo
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 15).ToString();
            }
        }

        public string TwentyThree
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 16).ToString();
            }
        }

        public string TwentyFour
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 17).ToString();
            }
        }

        public string TwentyFive
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 18).ToString();
            }
        }

        public string TwentySix
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 19).ToString();
            }
        }

        public string TwentySeven
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 20).ToString();
            }
        }

        public string TwentyEight
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 21).ToString();
            }
        }

        public string TwentyNine
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 22).ToString();
            }
        }

        public string Thirty
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 23).ToString();
            }
        }

        public string ThirtyOne
        {
            get
            {
                int sevenVal;
                int.TryParse(Seven, out sevenVal);
                return (sevenVal + 24).ToString();
            }
        }

        public string ThirtyTwo
        {
            get
            {
                return "1";
            }

        }

        public string ThirtyThree
        {
            get
            {
                return "2";
            }
        }

        public string ThirtyFour
        {
            get
            {
                return "3";
            }
        }

        public string ThirtyFive
        {
            get
            {
                return "4";
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
