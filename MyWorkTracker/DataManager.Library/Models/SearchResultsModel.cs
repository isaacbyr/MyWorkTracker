using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class SearchResultsModel
    {
        public string Job { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public decimal Wage { get; set; }
        public decimal SubTotal { get; set; }
    }
}
