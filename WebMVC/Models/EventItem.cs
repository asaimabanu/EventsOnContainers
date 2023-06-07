﻿namespace WebMvc.Models
{
    public class EventItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        //  public string Duration { get; set; }

        public DateTime EventStartDateTime { get; set; }

        public DateTime EventEndDateTIme { get; set; }

        //public int? EventLocationId { get; set; }

        public EventLocation EventLocation { get; set; }

        public bool IsOnline { get; set; }

        public int EventCategoryId { get; set; }

        public string EventCategory { get; set; }

        public int TicketQuantity { get; set; }
    }
}
