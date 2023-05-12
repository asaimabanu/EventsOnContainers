using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class EventCatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<EventItem> EventCatalogItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? CategoryFilterApplied { get; set; }
    }
}
