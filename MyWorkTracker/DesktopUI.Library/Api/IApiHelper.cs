using System.Net.Http;

namespace DesktopUI.Library.Api
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; set; }
    }
}