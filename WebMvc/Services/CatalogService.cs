using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _httpClient;
        public CatalogService(IConfiguration config, IHttpClient client)

        {
            _baseUrl = $"{config["CatalogUrl"]}/api/event";
            _httpClient = client;
        }
        public async Task<Catalog> GetEventItemsAsync(int page, int size, int? type, string? city)
        {
            var catalogItemsUri = APIPaths.Catalog.GetAllEventItems(_baseUrl, page, size, type, city);  
            var dataString = await _httpClient.GetStringAsync(catalogItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var locationUri = APIPaths.Catalog.GetAllLocations(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(locationUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var cities = JArray.Parse(dataString);
            foreach (var item in cities)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("city"),
                    Text = item.Value<string>("city"),
                });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = APIPaths.Catalog.GetAllTypes(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(typeUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var item in types)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("category"),
                });
            }
            return items;
        }
    }
}
