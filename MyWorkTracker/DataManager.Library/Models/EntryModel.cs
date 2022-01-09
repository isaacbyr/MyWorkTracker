using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class EntryModel
    {
        public string UserId { get; set; }
        public string Job { get; set; }
        public string Location { get; set; }
        public decimal Wage { get; set; }
        public decimal Hours { get; set; }
        public decimal Subtotal { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public DateTime JobDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

}
