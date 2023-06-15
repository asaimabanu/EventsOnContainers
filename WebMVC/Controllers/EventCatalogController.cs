using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventCatalogController : Controller
        {
        private readonly IEventCatalogService _service;


        public EventCatalogController(IEventCatalogService service)
            {
            _service = service;
            }
       
        public async Task<IActionResult> Index(int? page,
            int? categoryFilterApplied,
            int? eventTypeSelected, string? citySelected)

            {
            int itemsOnPage = 10;
            var EventCatalog = await _service.GetEventcatalogItemAsync(page ?? 0, itemsOnPage, categoryFilterApplied, eventTypeSelected, citySelected);


            var vm = new EventCatalogIndexViewModel
                {
                EventType = _service.GetEventTypes(),

                Cities = await _service.GetCitiesAsync(),
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
                EventTypeSelected = eventTypeSelected,
                CitySelected = citySelected

                };
            return View(vm);
            }


        [Authorize]
        public IActionResult About()
            {
            return View();
            }
    }
}
