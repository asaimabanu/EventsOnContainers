
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace WebMvc.Infrastructure
{
    public class ClustomHttpClientcs : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public ClustomHttpClientcs()
        {
            _httpClient = new HttpClient();
        }
        async Task<string> IHttpClient.GetStringAsync(string url, string authorizationToken, string authorizationMethod)
        {
            var  requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            var response = await _httpClient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
