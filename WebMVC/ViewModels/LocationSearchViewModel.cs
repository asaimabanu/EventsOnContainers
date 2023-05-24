using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMvc.ViewModels
    {
    public class LocationSearchViewModel
        {
        public bool? IsOnline {
            get { return IsOnline; }
            set
                {
                IsOnline = false;
                }
            }
        public IEnumerable<SelectListItem> State { get; set; }

        public IEnumerable<SelectListItem>? City { get; set; }
        public string? City_Selection { get; set; }

        public string? State_Selection { get; set; }

        }
    }
