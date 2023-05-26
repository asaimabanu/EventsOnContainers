

using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace WebMvc.Infrastructurenamespace WebMvc.Infrastructure
{
    public class ClustomHttpClientcs : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public ClustomHttpClientcs()
        {
            _httpClient = new HttpClient();
        }
        async Task<string> IHttpClient.GetStringAsync(string url, string authorizationtoken, string authorizationMethod)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
