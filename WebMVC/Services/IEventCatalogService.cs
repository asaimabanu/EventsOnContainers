using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<SelectListItem>> GetCitiesAsync();
        Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();

        //Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        IEnumerable<SelectListItem> GetEventTypes();
        Task<EventCatalog> GetEventcatalogItemAsync(int page, int take, int? category);
        Task<EventCatalog> GetEventcatalogItemAsync(int page, int take, int? category, int? isOnline, string? city);
        }
}
