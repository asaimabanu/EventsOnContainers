namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        Task<String> GetStringAsync(string url, string authorizationtoken = null, string authorizationMethod = "Bearer");
    
    }
}
