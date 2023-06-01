using EventsCatalogAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class EventTicket
    {
        [Key]
        public int TicketId { get; set; }
        public int? ShowID { get; set; }
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? SeatId { get; set; }
        public virtual EventShow? Show { get; set; }
        public virtual EventItem? EventItem { get; set; }
    }
}
