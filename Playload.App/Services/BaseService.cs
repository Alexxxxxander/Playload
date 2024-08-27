using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Playload.App.Services
{

    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;
        protected readonly string _apiKey;
        protected readonly string _placement = "vetmanager2.ru";

        protected BaseService(string baseUrl, string apiKey)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
            _apiKey = apiKey;
            _httpClient.DefaultRequestHeaders.Add("X-REST-API-KEY", apiKey);
        }

        protected async Task<string> GetAsync(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://{_baseUrl}.{_placement}{endpoint}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> PostAsync(string endpoint, HttpContent content)
        {
            var response = await _httpClient.PostAsync($"https://{_baseUrl}.{_placement}{endpoint}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> PutAsync(string endpoint, HttpContent content)
        {
            var response = await _httpClient.PutAsync($"https://{_baseUrl}.{_placement}{endpoint}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"https://{_baseUrl}.{_placement}{endpoint}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }

}
