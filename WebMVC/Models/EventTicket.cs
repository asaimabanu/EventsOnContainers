using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class EventTicket
    {
        [Key]
        public int TicketId { get; set; }
        public int EventId { get; set; }

        public int ShowId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        
        public string? SeatId { get; set; }
        public virtual EventItem? EventItem { get; set; }
        //public virtual EventShow? ShowTime { get; set; }
        public virtual string? EventName { get; set;}
    }
}
