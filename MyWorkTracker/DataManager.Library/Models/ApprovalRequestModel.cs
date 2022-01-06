using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class ApprovalRequestModel
    {
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        public bool Approved { get; set; }
    }
}
