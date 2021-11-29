﻿using Caliburn.Micro;
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
            firstDayOfMonth();
            await LoadTotals();
            NotifyOfPropertyChange(() => IsToday);
        }

        public async Task LoadTotals()
        {
            var result = await _entryEndpoint.LoadEntries();
           
            for (int i = 0; i < result.Count; i++)
            {
                //if(result[i].JobDate.Substring(0,2) == "16")
                //{
                //    T_One = result[i].Total.ToString("C");
                //}

                foreach (var entry in result)
                {
                    string testVariablle = entry.JobDate.Substring(0, 2);
                    switch(testVariablle)
                    {
                        case "1": 
                            T_One = entry.Total.ToString("C");
                            break;
                        case "2":
                            T_Two = entry.Total.ToString("C");
                            break;
                        case "3":
                            T_Three = entry.Total.ToString("C");
                            break;
                        case "4":
                            T_Four = entry.Total.ToString("C");
                            break;
                        case "5":
                            T_Five = entry.Total.ToString("C");
                            break;
                        case "6":
                            T_Six = entry.Total.ToString("C");
                            break;
                        case "7":
                            T_Seven = entry.Total.ToString("C");
                            break;
                        case "8":
                            T_Eight = entry.Total.ToString("C");
                            break;
                        case "9":
                            T_Nine = entry.Total.ToString("C");
                            break;
                        case "10":
                            T_Ten = entry.Total.ToString("C");
                            break;
                        case "11":
                            T_Eleven = entry.Total.ToString("C");
                            break;
                        case "12":
                            T_Twelve = entry.Total.ToString("C");
                            break;
                        case "13":
                            T_Thirteen = entry.Total.ToString("C");
                            break;
                        case "14":
                            T_Fourteen = entry.Total.ToString("C");
                            break;
                        case "15":
                            T_Fifteen = entry.Total.ToString("C");
                            break;
                        case "16":
                            T_Sixteen = entry.Total.ToString("C");
                            break;
                        case "17":
                            T_Seventeen = entry.Total.ToString("C");
                            break;
                        case "18":
                            T_Eighteen = entry.Total.ToString("C");
                            break;
                        case "19":
                            T_Nineteen = entry.Total.ToString("C");
                            break;
                        case "20":
                            T_Twenty = entry.Total.ToString("C");
                            break;
                        case "21":
                            T_TwentyOne = entry.Total.ToString("C");
                            break;
                        case "22":
                            T_TwentyTwo = entry.Total.ToString("C");
                            break;
                        case "23":
                            T_TwentyThree = entry.Total.ToString("C");
                            break;
                        case "24":
                            T_TwentyFour = entry.Total.ToString("C");
                            break;
                        case "25":
                            T_TwentyFive = entry.Total.ToString("C");
                            break;
                        case "26":
                            T_TwentySix = entry.Total.ToString("C");
                            break;
                        case "27":
                            T_TwentySeven = entry.Total.ToString("C");
                            break;
                        case "28":
                            T_TwentyEight = entry.Total.ToString("C");
                            break;
                        case "29":
                            T_TwentyNine = entry.Total.ToString("C");
                            break;
                        case "30":
                            T_Thirty = entry.Total.ToString("C");
                            break;
                        case "31":
                            T_ThirtyOne = entry.Total.ToString("C");
                            break;
                        case "32":
                            T_ThirtyTwo = entry.Total.ToString("C");
                            break;
                        case "33":
                            T_ThirtyThree = entry.Total.ToString("C");
                            break;
                        case "34":
                            T_ThirtyFour = entry.Total.ToString("C");
                            break;
                        case "35":
                            T_ThirtyFive = entry.Total.ToString("C");
                            break;
                        default: break;
                    }               
                }
            }
            
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
