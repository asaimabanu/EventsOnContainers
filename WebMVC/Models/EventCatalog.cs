namespace WebMvc.Models
{
    public class EventCatalog
    {
        public int pageIndex;
        public int pageSize;
        public long count;

        public IEnumerable<EventItem> Data {get; set; }
    }
}
