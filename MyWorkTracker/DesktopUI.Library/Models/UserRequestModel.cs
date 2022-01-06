using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Models
{
    public class UserRequestModel
    {
        public string Id { get; set; }
        public string ReqFirstName { get; set; }
        public string ReqLastName { get; set; }
        public bool Approved { get; set; }

    }
}
