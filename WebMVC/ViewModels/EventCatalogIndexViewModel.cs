using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventCatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<EventItem> EventCatalogItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? CategoryFilterApplied { get; set; }
    }
}
