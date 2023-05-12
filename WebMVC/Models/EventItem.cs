namespace WebMVC.Models
{
    public class EventItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string PictureUrl { get; set; }

        //  public string Duration { get; set; }

        public string EventStartDateTime { get; set; }

        public string EventEndDateTIme { get; set; }

        //public int? EventLocationId { get; set; }

        public string EventLocation { get; set; }

        public string IsOnline { get; set; }

        public string EventCategoryId { get; set; }

        public string EventCategory { get; set; }
    }
}
