using EventsCatalogAPI.Domain;

namespace EventsCatalogAPI.Model
{
    public class PaginatedViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<EventItem>? Data { get; set; }
        public long Count { get; set; }
    }
}
