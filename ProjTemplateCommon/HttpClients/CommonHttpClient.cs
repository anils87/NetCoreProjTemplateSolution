using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjTemplateCommon.ConfigClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjTemplateCommon.HttpClients
{
    public interface ICommonHttpClient
    {
        Task<CommonHttpClientResponse> GetExternalAPICall();
    }
    public class CommonHttpClient : ICommonHttpClient
    {
        public HttpClient httpClient { get; set; }
        private readonly JsonSerializerOptions _options;
        private readonly AppSettings _appSettings;

        //ILogger<CommonHttpClient> logger,IServiceProvider serviceProvider can be passed if any base class is there
        public CommonHttpClient(IOptions<AppSettings> appSettings) 
        {
            _appSettings = appSettings.Value;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<CommonHttpClientResponse> GetExternalAPICall()
        {
            
            //httpClient.BaseAddress = new Uri(_appSettings.ExternalConfig.apiUrl);
            var mainUrl = _appSettings.ExternalConfig.apiUrl;
            if (!mainUrl.EndsWith('/'))
            {
                mainUrl += "/";
            }
            var servicePath = mainUrl+ "technologies";
            var client = GetSecureHttpClient(servicePath, "test token");
            var response = client.GetAsync(servicePath).Result;
            if (response != null && response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CommonHttpClientResponse>(result);
            }
            else
                throw new ApplicationException($"GET {servicePath} returned invalid response.");
        }
        #region Base Class Methods
        public HttpClient GetSecureHttpClient(string serviceUrl,string bearerToken = null)
        {
            
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceUrl);
            AddHeadersToClient(ref httpClient,bearerToken);
            return httpClient;
        }
        public void AddHeadersToClient(ref HttpClient httpClient,string bearerToken = "")
        {
            httpClient.DefaultRequestHeaders.Add("transaction_id", "need to add transaction id for http client");
            
            if(!string.IsNullOrEmpty(bearerToken))
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",bearerToken);
        }
        #endregion
    }
}
