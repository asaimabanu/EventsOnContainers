using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventCatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<EventItem> EventCatalogItems { get; set; }

        public bool? IsOnline { get { return IsOnline;  } set { IsOnline = false; } }

        public string[] Online_Options = new[] { "Yes", "No" }; 

        public IEnumerable<SelectListItem> State { get; set; }
        public LocationSearchViewModel LocationSearch { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? CategoryFilterApplied { get; set; }

        public string? State_Selected { get; set; }
        }
}
