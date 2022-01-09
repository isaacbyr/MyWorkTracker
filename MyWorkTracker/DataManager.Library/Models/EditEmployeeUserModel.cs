using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class EditEmployeeUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Wage { get; set; }
        public decimal BilledOut { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
