namespace WebMvc.Models.OrderModels
{
    public class OrderItem
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public decimal UnitPrice { get; set; }


        public int Units { get; set; }

        public string PictureUrl { get; set; }
    }
}
