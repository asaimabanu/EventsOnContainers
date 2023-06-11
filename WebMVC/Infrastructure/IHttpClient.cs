namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        Task<String> GetStringAsync(string url, string authorizationtoken = null, string authorizationMethod = "Bearer");

        //Task<String> GetLocationsAsync();
        Task<String> GetCitiesAsync();

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item,
          string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> DeleteAsync(string uri,
            string authorizationToken = null, string authorizationMethod = "Bearer");
    }
}
