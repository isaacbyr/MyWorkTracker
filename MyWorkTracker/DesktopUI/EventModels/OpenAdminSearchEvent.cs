using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.EventModels
{
    public class OpenAdminSearchEvent
    {
        public int CompanyId { get; set; }

        public OpenAdminSearchEvent(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
