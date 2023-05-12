using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService _service;
        public EventCatalogController(IEventCatalogService service)
        {
            _service = service;

        }
        public async Task<IActionResult> IndexAsync(int? page, int? categoryFilterApplied)
        {
            int itemsOnPage = 10;
            var EventCatalog = await _service.GetEventcatalogItemAsync(page ?? 0, itemsOnPage, categoryFilterApplied);
            var vm = new EventCatalogIndexViewModel
            {
                Category = await _service.GetEventCategoriesAsync(),
                EventCatalogItems = EventCatalog.Data,

                PaginationInfo = new PaginationInfo
                {
                    ActualPage = EventCatalog.pageIndex,
                    TotalItems = EventCatalog.count,
                    ItemsPerPage = EventCatalog.pageSize,
                    TotalPages = (int)Math.Ceiling((decimal)EventCatalog.count / itemsOnPage)
                },
                CategoryFilterApplied = categoryFilterApplied,

            };
            return View(vm);
        }
    }
}
