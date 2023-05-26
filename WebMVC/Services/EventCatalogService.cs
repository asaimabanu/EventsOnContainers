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
                 _baseUrl = $"{config["CatalogUrl"]}/api/Event";
                 _httpClient = client;
            }
        public async Task<EventCatalog> GetEventcatalogItemAsync(int page, int take, 
            int? category)
        {
            string uri = APIPaths.EventCatalog.GetEvents(_baseUrl,page,take,category);
            var dataString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<EventCatalog>(dataString);

        }

        public async Task<EventCatalog> GetEventcatalogItemAsync(int page, int take,
           int? category, int? isOnline, string? city)
            {
            string uri = APIPaths.EventCatalog.GetEvents(_baseUrl, page, take, category, isOnline, city);
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
                    Text = item.Value<String>("category"),
                    Value = item.Value<String>("id")
                });
            }
            return items;
        }

        public IEnumerable<SelectListItem> GetEventTypes()
            {
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "All",
                    Value = null,
                    Selected= true,
                },
                new SelectListItem
                {
                    Text = "Location",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Online",
                    Value = "2"
                }

            };
            return items;
            }
        /*public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
            {
            var items = new List<SelectListItem>
                    {
                    new SelectListItem
                    {
                        Text = "All",
                        Value = null,
                        Selected = true,
                    }

                    };

            string response = await _httpClient.GetLocationsAsync();

            if (response != string.Empty)
                {
                JArray state_list = JArray.Parse(response.ToString());

                foreach (var item in state_list)
                    {
                    items.Add(new SelectListItem
                        {
                        Text = item.Value<String>("name"),
                        Value = item.Value<String>("state_code")
                        });
                    }
                return items;
                }

            return items;
            }*/

        public async Task<IEnumerable<SelectListItem>> GetCitiesAsync()
            {
                {
                var items = new List<SelectListItem>
                    {
                    new SelectListItem
                    {
                        Text = "--select city--",
                        Value = null,
                        Selected = true,
                    },
                    new SelectListItem
                    {
                        Text = "Seattle",
                        Value = "Seattle",
                   
                    },
                    new SelectListItem
                    {
                        Text = "Denver",
                        Value = "Denver",
                        
                    },
                    new SelectListItem
                    {
                        Text = "San Francisco",
                        Value = "San Francisco",
                        
                    },
                    new SelectListItem
                    {
                        Text = "New York",
                        Value = "New York",
                      
                    },
                    new SelectListItem
                    {
                        Text = "Michigan",
                        Value = "Michigan",
                       
                    },
                    new SelectListItem
                    {
                        Text = "Bellevue",
                        Value = "Bellevue",
                        
                    },
                    new SelectListItem
                    {
                        Text = "Redmond",
                        Value = "Redmond",
                        
                    },

                    };
                
                /*string response = await _httpClient.GetCitiesAsync();

                if (response != string.Empty)
                    {
                    JArray city_list = JArray.Parse(response.ToString());

                    foreach (var item in city_list)
                        {
                        items.Add(new SelectListItem
                            {
                            Text = item.Value<String>("value"),
                            Value = item.Value<String>("value")
                            });
                        }
                    return items;
                    }*/

                return items;
                }
            }

        }
    }
