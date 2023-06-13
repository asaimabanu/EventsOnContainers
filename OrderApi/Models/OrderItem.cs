using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EventName { get; set; }
        public string PictureUrl { get; set; }
        public decimal TicketPrice { get; set; }
        public int Units { get; set; }
        public int EventId { get;  set; }
        public int OrderId { get; set; }

        public OrderItem(int eventId, string eventName, decimal ticketPrice, string pictureUrl, int units = 1)
        {
            EventId = eventId;

            EventName = eventName;
            TicketPrice = ticketPrice;

            Units = units;
            PictureUrl = pictureUrl;
        }

        public void SetPictureUri(string pictureUri)
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                PictureUrl = pictureUri;
            }
        }

        public void AddUnits(int units)
        {
            Units += units;
        }
    }
}

