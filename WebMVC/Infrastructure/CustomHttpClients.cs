using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebMvc.Infrastructure
{
    public class CustomHttpClients : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public CustomHttpClients()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetStringAsync(string uri, 
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            if (authorizationToken != null)
                {
                request.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod,authorizationToken);
                }
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        /*public async Task<string> GetLocationsAsync()
            {
          
            var request = new HttpRequestMessage(HttpMethod.Get, "https://city-and-state-search-api.p.rapidapi.com/states?country_code=US");
            request.Headers.Add("X-RapidAPI-Key", "913631da8dmsh024dc5ee4956684p1d7e35jsna7fe978ff01c");
            request.Headers.Add("X-RapidAPI-Host", "city-and-state-search-api.p.rapidapi.com");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
                {
                //Console.WriteLine(response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
                }
            else
                {
                return new string("");
                }
            
            }*/

        public async Task<string> GetCitiesAsync()
            {
            var uri = $"https://referential.p.rapidapi.com/v1/city?state_code=US-WA";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("X-RapidAPI-Key", "913631da8dmsh024dc5ee4956684p1d7e35jsna7fe978ff01c");
            request.Headers.Add("X-RapidAPI-Host", "referential.p.rapidapi.com");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
                    {
                    //Console.WriteLine(response.Content.ReadAsStringAsync());
                    return await response.Content.ReadAsStringAsync();
                    }
                else
                    {
                    return new string("");
                    }
                }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
            {
            return await DoPostPutAysnc(HttpMethod.Post, uri, item, authorizationToken, authorizationMethod);
            }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
            {
            return await DoPostPutAysnc(HttpMethod.Put, uri, item, authorizationToken, authorizationMethod);
            }

        private async Task<HttpResponseMessage> DoPostPutAysnc<T>(HttpMethod method, string uri,
            T item, string authorizationToken, string authorizationMethod)
            {
            var requestMessage = new HttpRequestMessage(method, uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item),
                System.Text.Encoding.UTF8, "application/json");
            if (authorizationToken != null)
                {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
                }
            var response = await _httpClient.SendAsync(requestMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                throw new HttpRequestException();
                }
            return response;
            }

        public async Task<HttpResponseMessage> DeleteAsync(string uri,
            string authorizationToken = null, string authorizationMethod = "Bearer")
            {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            if (authorizationToken != null)
                {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod,
                    authorizationToken);
                }
            return await _httpClient.SendAsync(requestMessage);
            }
        }
}
