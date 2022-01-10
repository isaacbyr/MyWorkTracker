using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.EventModels
{
    public class OpenContactsEvent
    {
        public int CompanyId { get; set; }

        public OpenContactsEvent(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
