namespace WebMvc.Models
    {
    public class EventLocation
        {
        public string Id { get; set; }
        public string EventID { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }
        }
    }
