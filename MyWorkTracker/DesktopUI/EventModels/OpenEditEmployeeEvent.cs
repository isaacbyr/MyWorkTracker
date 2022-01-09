using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.EventModels
{
    public class OpenEditEmployeeEvent
    {
        public string Id { get; set; }

        public OpenEditEmployeeEvent(string id)
        {
            Id = id;
        }
    }
}
