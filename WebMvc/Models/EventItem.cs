namespace WebMvc.Models
{
    public class EventItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public DateTime EventStartDateTime { get; set; }

        public DateTime? EventEndDateTime { get; set; }

        public bool IsOnlineEvent { get; set; }


        public int EventCategoryId { get; set; }

        public int EventLocationId { get; set; }

        public string EventLocation { get; set; }

        public string EventCategory { get; set; }
    }
}
