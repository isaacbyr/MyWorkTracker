using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class LoggedInUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
