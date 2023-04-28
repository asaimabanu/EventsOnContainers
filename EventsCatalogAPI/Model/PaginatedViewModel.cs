namespace EventsCatalogAPI.Model
{
    public class PaginatedViewModel
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public object Data { get; set; }
        public long Count { get; set; }
    }
}
