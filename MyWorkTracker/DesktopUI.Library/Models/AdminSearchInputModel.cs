using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Models
{
    public class AdminSearchInputModel
    {
        public int CompanyId { get; set; }
        public string Keyword { get; set; }
        public string Category { get; set; }
        public string OrderBy { get; set; }
    }
}
