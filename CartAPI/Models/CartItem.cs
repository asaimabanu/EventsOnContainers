namespace CartAPI.Models
    {
    public class CartItem
        {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string PictureUrl { get; set; }
        public decimal TicketPrice { get; set; }
        public int Quantity { get; set; }
        public decimal OldTicketPrice { get; set; }
        }
    }
