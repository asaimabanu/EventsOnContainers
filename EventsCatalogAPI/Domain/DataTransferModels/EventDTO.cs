namespace EventsCatalogAPI.Domain.DataTransferModels
    {
    public class EventDTO
        {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public DateTime EventStartDateTime { get; set; }

        public DateTime EventEndDateTIme { get; set; }

        public EventLocation EventLocation { get; set; }

        public bool IsOnline { get; set; }

        public int EventCategoryId { get; set; }

        public EventCategory EventCategory { get; set; }

        public int TicketQuantity { get; set; }
        }
    }
