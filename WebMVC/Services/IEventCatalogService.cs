using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();

        Task<EventCatalog> GetEventcatalogItemAsync(int page, int take, int? category);
    }
}
