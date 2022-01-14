using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class SearchResultsEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public decimal Hours { get; set; }
        public decimal Wage { get; set; }
        public decimal Total { get; set; }
    }
}
