using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventController : Controller
    {
        private readonly ICatalogService _service;
        public EventController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? typeFilterApplied, string? cityFilterApplied)
        {
            int itemsOnPage = 10;
            var catalog = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, typeFilterApplied, cityFilterApplied);
            var vm = new CatalogIndexViewModel
            {
                Types = await _service.GetTypesAsync(),
                Locations = await _service.GetLocationsAsync(),
                EventItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = catalog.PageIndex,
                    TotalItems = catalog.Count,
                    ItemsPerPage = catalog.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                TypesFilterApplied = typeFilterApplied,
                CityFilterApplied = cityFilterApplied

            };
            return View(vm);
        }
    }
}
