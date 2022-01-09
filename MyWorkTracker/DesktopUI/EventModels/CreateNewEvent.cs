using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.EventModels
{
    public class CreateNewEvent
    {
        public bool PrevMonth { get; set; }
        public bool NextMonth { get; set; }
        public string Date { get; set; }
        public DateTime SelectedDate { get; set; }
        public string ItemLocation { get; set; }

        public CreateNewEvent(string date)
        {
            Date = date;
        }

        public CreateNewEvent()
        {

        }

        public CreateNewEvent(string date, bool prevMonth, bool nextMonth, DateTime selectedDate, string itemLocation)
        {
            Date = date;
            PrevMonth = prevMonth;
            NextMonth = nextMonth;
            SelectedDate = selectedDate;
            ItemLocation = itemLocation;
        }
    }
}
