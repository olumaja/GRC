using GrcApi.Modules.Shared.Enums;

namespace GrcApi.Modules.Shared.RestHelper
{
    public interface IRestHelper
    {
        Task<Result<T>> ConsumeApi<T>(string httpNamedClient, string url, object payload, HttpVerb type = HttpVerb.Get, Dictionary<string, string> headers = null);
    }
}
