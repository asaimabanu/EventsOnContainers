namespace WebMVC.Infrastructure
{
    public class CustomHttpClientcs : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public CustomHttpClientcs()
        {
            _httpClient = new HttpClient();
        }
        async Task<string> IHttpClient.GetStringAsync(string url, string authorizationtoken, string authorizationMethod)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
