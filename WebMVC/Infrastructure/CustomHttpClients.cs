using Microsoft.AspNetCore.DataProtection.KeyManagement;
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
        }
}
