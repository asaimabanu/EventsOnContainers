namespace EventsCatalogAPI.Domain
{
    public class EventLocation
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2{ get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }


        //public EventLocation()
        //{

        //}

        //public EventLocation(string addressline1,string addressline2,string city,string state,string zipcode)
        //{
        //    this.AddressLine1 = addressline1;
        //    this.AddressLine2 = addressline2;
        //    this.City = city;
        //    this.State = state;
        //    this.ZipCode = zipcode;
        //}
    }
}
