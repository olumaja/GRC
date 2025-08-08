using GrcApi.Modules.Shared.Enums;
using Newtonsoft.Json;
using System.Text;

namespace GrcApi.Modules.Shared.RestHelper
{
    public class RestHelper : IRestHelper
    {
        private readonly IHttpClientFactory httpClient;
        private readonly Serilog.ILogger logger;

        public RestHelper(IHttpClientFactory httpClient, Serilog.ILogger logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }
        public async Task<Result<T>> ConsumeApi<T>(string httpNamedClient, string url, object payload, HttpVerb type = HttpVerb.Get, Dictionary<string, string> headers = null)
        {
            var apiResult = new Result<T>();

            try
            {
                var client = httpClient.CreateClient(httpNamedClient);
                var requestMessage = new HttpRequestMessage();
                requestMessage.RequestUri = new Uri(url);

                switch(type)
                {
                    case HttpVerb.Post:
                        requestMessage.Method = HttpMethod.Post;
                        break;
                    case HttpVerb.Put:
                        requestMessage.Method = HttpMethod.Put;
                        break;
                    case HttpVerb.Patch:
                        requestMessage.Method = HttpMethod.Patch;
                        break;
                    case HttpVerb.Delete:
                        requestMessage.Method = HttpMethod.Delete;
                        break;
                    default:
                        requestMessage.Method = HttpMethod.Get;
                        break;
                }

                if(headers != null)
                {
                    foreach( var header in headers)
                    {
                        requestMessage.Headers.Add(header.Key, header.Value);
                    }
                }

                var serializepayload = JsonConvert.SerializeObject(payload);

                if(payload != null)
                {
                    requestMessage.Content = new StringContent(serializepayload, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response;

                if(type == HttpVerb.Get && headers == null)
                {
                    response = await client.GetAsync(url);
                }
                else if(type == HttpVerb.Post && headers == null) {
                    response = await client.PostAsync(url, requestMessage.Content);
                }
                else
                {
                    response = await client.SendAsync(requestMessage);
                }

                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    apiResult.Content = JsonConvert.DeserializeObject<T>(result);
                    apiResult.Message = "Success";
                    apiResult.IsSuccess = true;
                    apiResult.StatusCode = response.StatusCode.ToString();
                    return apiResult;
                }

                apiResult.StatusCode = response.StatusCode.ToString();
                logger.Information($"Status code {response.StatusCode}");
                apiResult.Message = "Failed";
                return apiResult;
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                apiResult.Content = (T)(object)null;
                apiResult.Message = ex.Message;
                return apiResult;
            }
        }
    }
}
