using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.EventModels
{
    public class OpenAdminStatsView
    {
        public int CompanyId { get; set; }

        public OpenAdminStatsView(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
