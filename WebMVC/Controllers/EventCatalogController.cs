using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        /*public async Task<IActionResult> Search(string? selected_state)
            {
            var State_Selected = selected_state;
            var vm = new LocationSearchViewModel
                {
                State = 
                //State_Selection = selected_state.ToString()
            };

                
            return View(vm);
            }*/
        public async Task<IActionResult> Index(int? page, int? categoryFilterApplied)
        {
            int itemsOnPage = 10;
            var EventCatalog = await _service.GetEventcatalogItemAsync(page ?? 0, itemsOnPage, categoryFilterApplied);
            var vm = new EventCatalogIndexViewModel
                {
                Category = await _service.GetEventCategoriesAsync(),
                EventCatalogItems = EventCatalog.Data,
                
                State = await _service.GetLocationsAsync(),

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

        [Authorize]
        public IActionResult About()
            {
            return View();
            }
    }
}
