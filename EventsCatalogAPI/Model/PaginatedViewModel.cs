using EventsCatalogAPI.Domain;

namespace EventsCatalogAPI.Model
{
    public class PaginatedViewModel
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public List<EventItem> Data { get; set; }
        public long Count { get; set; }
    }
}
