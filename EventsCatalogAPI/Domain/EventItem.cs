//using Microsoft.EntityFrameworkCore.Query;

namespace EventsCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public string PictureUrl {get ; set;}

      //  public string Duration { get; set; }
        
        public DateTime EventStartDateTime { get; set; }

        public DateTime EventEndDateTIme { get; set; }

        //public int? EventLocationId { get; set; }
        
        public virtual EventLocation EventLocation { get; set; }
        
        public bool  IsOnline { get; set;}
        
        public int EventCategoryId { get; set; }
        
        public virtual EventCategory EventCategory { get; set; }
        //create a blank solution 
        // create a solution folder src 
        //in that create a services solution folder 
        //create a web solution folder all three r virtual folders 
        //int services create a new Project eventscatalalog api 
        //in events catalog api create a domain folder (domain=models )
        //create 3 classes in domain eventtype ,eventCategory and eventitem 
        //right clicl on events ctalog Api then select nuget packages install entity framwork core,
        //2.e framwork sqlserver 6.16
        //3.e framwork relational6.16
        //4.eframwork tools 6.16 

    }

}
