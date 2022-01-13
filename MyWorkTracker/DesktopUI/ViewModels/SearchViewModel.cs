using Caliburn.Micro;
using DesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class SearchViewModel: Screen
    {
        private readonly IEntryEndpoint _entryEndpoint;

        public SearchViewModel(IEntryEndpoint entryEndpoint)
        {
            _entryEndpoint = entryEndpoint;
        }


    }
}
