using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<EventItem> EventItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? TypesFilterApplied { get; set; }
        public string? CityFilterApplied { get; set; }



    }
}
