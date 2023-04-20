using Microsoft.EntityFrameworkCore.Query;

namespace EventsCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl {get ; set;}

        public string Duration { get; set; }
        public DateTime EventDate { get; set; }
        
        public string EventAddress { get; set; }
        public int EventTypeId { get; set;}
        public int EventBrandId { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual EventBrand EventBrand { get; set; }
        //create a blank solution 
        // create a solution folder src 
        //in that create a services solution folder 
        //create a web solution folder all three r virtual folders 
        //int services create a new ProjectionBindingExpression eventscatalalog api 
        //in events catalog api create a domain folder (domain=models )
        //create 3 classes in domain eventtype ,eventbrand and eventitem 
        //right clicl on events ctalog Api then select nuget packages install entity framwork core,
        //2.enettoty framwork sqlserver 6.16
        //3.enettoty framwork relational6.16
        //4.nettoty framwork tools 6.16 

    }

}
