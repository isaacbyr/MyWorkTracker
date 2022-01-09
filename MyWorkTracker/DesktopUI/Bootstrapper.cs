using Caliburn.Micro;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopUI
{
    public class Bootstrapper: BootstrapperBase
    {
        private SimpleContainer container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container
                .Singleton<IWindowManager, WindowManager>()
                //.Singleton<ILoggedInUserModel, LoggedInUserModel>()
                .Singleton<IApiHelper, ApiHelper>()
                .Singleton<IChartEndpoint, ChartEndpoint>()
                .Singleton<IEntryEndpoint, EntryEndpoint>()
                .Singleton<ICompanyEndpoint, CompanyEndpoint>()
                .Singleton<IUserEndpoint, UserEndpoint>()
                .Singleton<IRequestEndpoint, RequestEndpoint>()
                .Singleton<IProductEndpoint, ProductEndpoint>()
                .Singleton<IEventAggregator, EventAggregator>();

            container.Instance(container);

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

    }
}
