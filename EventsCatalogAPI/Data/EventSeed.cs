using EventsCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            context.Database.Migrate();
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetEventCategories());
                context.SaveChanges();

            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetEventItems());
                context.SaveChanges();

            }
        }

        private static IEnumerable<EventCategory> GetEventCategories()
        {
            return new List<EventCategory>
          {
              new EventCategory{Category="Auto,Boat Air"},
              new EventCategory{Category="Business Professional"},
              new EventCategory{Category="Charity Causes"}
          };
        }

        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
          {
              new EventItem{EventCategoryId = 3, 
                            Title = "Seattle Mom Prom",
                            Description = "An evening of drinks, desserts, dancing and FUN -- the ultimate ladies night out! All benefiting Perinatal Support Washington!", 
                            Price = 99.5M, 
                            PictureUrl = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F430701329%2F1361799702583%2F1%2Foriginal.20230124-002154?w=940&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C71%2C1124%2C562&s=6d7a248de52f8fb8f551ea4278e8b394",
                            EventStartDateTime = new DateTime(2023,5,8,18,0,0),
                            EventEndDateTIme = new DateTime(2023,5,8,21,0,0)},


              new EventItem{EventCategoryId = 2,
                            Title = "Tech Career Fair",
                            Description = "Seattle Tech Career Fair: Exclusive Tech Hiring Event",
                            Price = 0.0M,
                            PictureUrl = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F129223019%2F197361445633%2F1%2Foriginal.20210316-120602?w=512&auto=format%2Ccompress&q=75&sharp=10&rect=173%2C0%2C2160%2C1080&s=20df210f60f3d4b78b4cb633133fa590",
                            EventStartDateTime = new DateTime(2023,5,23,9,0,0),
                            EventEndDateTIme = new DateTime(2023,5,23,18,0,0)},

              new EventItem{EventCategoryId = 1,
                            Title = "MCS Night at the Races",
                            Description = "Join fellow MCS Families for a special night at the races. This TAPP event helps raise funds to support our students and teachers.",
                            Price = 20.0M,
                            PictureUrl = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F496857949%2F173096092901%2F1%2Foriginal.20230420-030912?w=940&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C52%2C1640%2C820&s=6a52f9a1238aa65bf5f963f95c042239",
                            EventStartDateTime = new DateTime(2023,6,12,18,0,0),
                            EventEndDateTIme = new DateTime(2023,6,12,21,0,0)},
          };
        }
    }
}
