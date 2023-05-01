namespace EventsCatalogAPI.Domain
{
    public class EventLocation
    {
        public int Id { get; set; }
        public int EventID { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }

        public virtual EventItem  EventItem {get; set;}

    }
}
