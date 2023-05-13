using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services

{
    public class EventCatalogService:IEventCatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _httpClient;
        public EventCatalogService(IConfiguration config, IHttpClient client)
             {
                 _baseUrl = $"{config["CatalogUrl"]}/api/event";
                 _httpClient = client;
            }
        public async Task<EventCatalog> GetEventcatalogItemAsync(int page, int take, int? category)
        {
            string uri = APIPaths.EventCatalog.GetEvents(_baseUrl,page,take,category);
            var dataString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<EventCatalog>(dataString);

        }

       public async Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync()
       {
            string uri = APIPaths.EventCatalog.GetAllCategories(_baseUrl);
            var datastring = await _httpClient.GetStringAsync(uri);
            var eventItems = JArray.Parse(datastring);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "All",
                    Value = null,
                    Selected= true,
                }
            };
            
            foreach ( var item in eventItems )
            {
                items.Add(new SelectListItem
                {
                    Text = item.Value<String>("Category"),
                    Value = item.Value<String>("Id")
                });
            }
            return items;
        }
    
    }
}
