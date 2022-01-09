using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.EventModels
{
    public class AdminCreateNewEvent
    {
        public bool PrevMonth { get; set; }
        public bool NextMonth { get; set; }
        public string Date { get; set; }
        public DateTime SelectedDate { get; set; }
        public int CompanyId { get; set; }

        public AdminCreateNewEvent(string date, bool prevMonth, bool nextMonth, DateTime selectedDate, int companyId)
        {
            Date = date;
            PrevMonth = prevMonth;
            NextMonth = nextMonth;
            SelectedDate = selectedDate;
            CompanyId = companyId;
        }
    }
}
