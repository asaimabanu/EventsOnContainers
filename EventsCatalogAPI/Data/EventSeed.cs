using EventsCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            //context.Database.Migrate();
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
              new EventCategory{Category="Music"},
              new EventCategory{Category="Performing & Visual Arts events"},
              new EventCategory{Category="Holiday"},
              new EventCategory{Category = "Health"},
              new EventCategory{Category = "Other"}
          };
        }

        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
          {
              new EventItem{EventCategoryId = 1, 
                            Title = "Ancient drumming workshop with Heilung’s Jacob Lund",
                            Description = "Explore the ancient art of drumming with Denmark’s Jacob Lund, of the band Heilung", 
                            Price = 130, 
                            PictureUrl = "https://sampledomain/api/pic/1",
                            EventStartDateTime = new DateTime(2023,5,26,17,0,0),
                            EventEndDateTIme = new DateTime(2023,5,26,20,0,0),
                            EventLocation = new EventLocation
                            {
                                AddressLine1= "Teatro de la Psychomachia ",
                                AddressLine2 ="1534 1st Avenue",
                                City = "Seattle",
                                State = "WA",
                                ZipCode = "98134"
                            }
              },


              new EventItem{EventCategoryId = 2,
                            Title = "Venice is Sinking Masquerade Ball 2023",
                            Description = "Venice is Sinking Masquerade Ball ~ NEW VENUE!",
                            Price = 15,
                            PictureUrl = "https://sampledomain/api/pic/2",
                            EventStartDateTime = new DateTime(2023,5,20,9,0,0),
                            EventEndDateTIme = new DateTime(2023,5,21,1,0,0),
                            EventLocation = new EventLocation
                            {
                                AddressLine1= "House of Smith Jet City Winery 1136 South",
                                AddressLine2 ="Albro Place",
                                City = "Seattle",
                                State = "WA",
                                ZipCode = "98108"
                            }
              },

              new EventItem{EventCategoryId = 2,
                            Title = "Family Magic Show at the Seattle Center",
                            Description = "Family Friendly Magic Show at the Seattle Center. Free Admission. Artful theatrical magic to amaze and entertain kids and adults.",
                            Price = 0,
                            PictureUrl = "https://sampledomain/api/pic/3",
                            EventStartDateTime = new DateTime(2023,4,29,13,0,0),
                            EventEndDateTIme = new DateTime(2023,4,29,13,45,0),
                            EventLocation = new EventLocation
                            {
                                AddressLine1= "Theater Puget Sound 305 Harrison Street",
                                AddressLine2 ="",
                                City = "Seattle",
                                State = "WA",
                                ZipCode = "98109"
                            }

              },
               new EventItem{EventCategoryId = 3,
                            Title = "Empress Yacht July 4th Fireworks Party Cruise",
                            Description = "A July 4th party cruise aboard the Empress yacht with a panoramic view of the San Francisco skyline under the stars and city lights",
                            Price = 169,
                            PictureUrl = "https://sampledomain/api/pic/4",
                            EventStartDateTime = new DateTime(2023,7,4,19,30,0),
                            EventEndDateTIme = new DateTime(2023,7,4,11,45,0),
                            EventLocation = new EventLocation
                            {
                                AddressLine1= "Pier 40 89 King Street ",
                                //AddressLine2 ="",
                                City = "San Francisco",
                                State = "CA",
                                ZipCode = "94107"
                            }
              },
                new EventItem{EventCategoryId = 4,
                            Title = "SOUND BATH IN REDWOOD GROVE - GOLDEN GATE PARK",
                            Description = "The Logos Method ~ SOUND BATH ~ APRIL 29, 2022",
                            Price = 40,
                            PictureUrl = "https://sampledomain/api/pic/5",
                            EventStartDateTime = new DateTime(2023,4,29,15,0,0),
                            EventEndDateTIme = new DateTime(2023,4,29,16,30,0),
                            EventLocation = new EventLocation
                            {
                                AddressLine1= "National AIDS Memorial Grove Bowling",
                                AddressLine2 ="Green Drive",
                                City = "San Francisco",
                                State = "CA",
                                ZipCode = "94122"
                            }
              },
               new EventItem{EventCategoryId = 5,
                            Title = "Come Meet A Black Person\" Anti-Racism Virtual Series",
                            Description = "\"Come Meet A Black Person\" anti-racism virtual event where non-Blacks talk about racism and eradicating racism with Blacks .",
                            Price = 200,
                            PictureUrl = "https://sampledomain/api/pic/6",
                            EventStartDateTime = new DateTime(2023,5,14,12,0,0),
                            EventEndDateTIme = new DateTime(2023,5,14,14,0,0),
                            IsOnline= true,
                          
              }
          };
        }
    }
}
