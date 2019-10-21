using KonusarakOgren.Business.Proxies.Interfaces;
using KonusarakOgren.Models.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KonusarakOgren.Business.Proxies
{
    public class WiredApiProxy : IWiredApiProxy
    {
        public readonly HttpClient _httpClient;
        public readonly IConfiguration _configuration;

        public WiredApiProxy(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WiredApiResponse> GetWiredArticles()
        {
            var newsApiKey = _configuration["NewsApiKey"];
            var uri = $"/v2/top-headlines?sources=wired&apiKey={newsApiKey}";
            var restResponse = await _httpClient.GetAsync(uri);

            if(restResponse.StatusCode == HttpStatusCode.OK)
            {
                var content = await restResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<WiredApiResponse>(content);

                return response;
            }

            var errorMessage = $"{nameof(WiredApiProxy)} {nameof(GetWiredArticles)} throws exception status code: {restResponse.StatusCode} error: {restResponse.Content}";
            throw new Exception(errorMessage);
        }
    }
}
