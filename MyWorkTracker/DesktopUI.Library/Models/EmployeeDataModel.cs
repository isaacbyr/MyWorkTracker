using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Models
{
    public class EmployeeDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public string Location { get; set; }
        public decimal Hours { get; set; }
        public decimal Wage { get; set; }
        public decimal BilledOut { get; set; }
        public decimal SubTotal { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
