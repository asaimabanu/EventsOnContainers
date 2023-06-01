using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventCatalogIndexViewModel
    {
        //private List<SelectListItem> options;
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> EventType { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<EventItem> EventCatalogItems { get; set; }

        //public IEnumerable<SelectListItem> State { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? EventTypeSelected { get; set; }
        public string? CitySelected { get; set; }
         //public string? State_Selected { get; set; }
        }
}
