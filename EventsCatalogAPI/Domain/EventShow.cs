using System.ComponentModel.DataAnnotations;

namespace EventsCatalogAPI.Domain
{
    public class EventShow
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; }
        //public int ShowId { get; set; }
        public DateTime ShowDate { get; set; }
        public DateTime ShowTime { get; set; }
        public int TicketQuantity { get; set; }
        public virtual EventItem EventItem { get; set; }
    }
}
