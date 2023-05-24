using System.Net.Http.Headers;

namespace WebMvc.Infrastructure
{
    public class CustomHttpClientcs : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public CustomHttpClientcs()
        {
            _httpClient = new HttpClient();
        }
        async Task<string> IHttpClient.GetStringAsync(string url, 
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (authorizationToken != null)
                {
                request.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod,authorizationToken);
                }
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
