using EventsCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();

            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetEventCategories());
                context.SaveChanges();
            }

            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetEventLocations());
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
              new EventCategory{Category = "Other"},
              new EventCategory{Category = "Business"},
              new EventCategory{Category = "Hobbies"},
              new EventCategory{Category = "Food & Drink"},
              new EventCategory{Category = "Sports & Fitness"}
          };
        }

        private static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>
          {
              new EventLocation
              {
                Name = "University Village",
                AddressLine1 = "2623 NE University Village St",
                City = "Seattle",
                State = "WA",
                ZipCode = "98105"
              },

              new EventLocation
              {
                Name = "West Technical Education Center",
                AddressLine1 = "2625 NW 16th St",
                City = "Belle Glade",
                State = "FL",
                ZipCode = "33430"
              },

              new EventLocation
              {
                Name = "Evergreen Speedway",
                AddressLine1 = "14405 179th Avenue Southeast",
                City = "Monroe",
                State = "WA",
                ZipCode = "98272"
              },

              new EventLocation
              {
                Name= "Teatro de la Psychomachia",
                AddressLine1 ="1534 1st Avenue SE",
                City = "Seattle",
                State = "WA",
                ZipCode = "98134"
              },

              new EventLocation
              {
                Name = "House of Smith Jet City Winery",
                AddressLine1= "1136 S Albro Pl",
                City = "Seattle",
                State = "WA",
                ZipCode = "98108"
              },

              new EventLocation
              {
                Name= "Theater Puget Sound",
                AddressLine1 = "Armory, 305 Harrison St",
                City = "Seattle",
                State = "WA",
                ZipCode = "98109"
              },

              new EventLocation
              {
                Name = "Pier 40",
                AddressLine1 = "89 King St",
                City = "San Francisco",
                State = "CA",
                ZipCode = "94107"
              },

              new EventLocation
              {
                Name = "National AIDS Memorial Grove",
                AddressLine1 = "Bowling Green Dr",
                City = "San Francisco",
                State = "CA",
                ZipCode = "94122"
              },

              new EventLocation
              {
                Name = "The Infinite Monkey Theorem",
                AddressLine1 = "3200 Larimer Street",
                City = "Denver",
                State = "CO",
                ZipCode = "80205"
              },

              new EventLocation
              {
                Name = "AC Bar and Kitchen",
                AddressLine1 = "750 15th Street",
                City = "Denver",
                State = "CO",
                ZipCode= "80202"
              },

              new EventLocation
              {
                Name = "Mykonos Blue Rooftop",
                AddressLine1 = "127 W 28th Street",
                City = "New York",
                State = "NY",
                ZipCode = "10001"
              },

              new EventLocation
              {
                Name = "Yara",
                AddressLine1 = "319 E 53rd Street",
                City = "New York",
                State = "NY",
                ZipCode = "10022"
              },

              new EventLocation
              {
                Name = "Microsoft Experience Center (3rd and 5th Floors)",
                AddressLine1 = "677 5th Avenue",
                City = "New York",
                State = "NY",
                ZipCode = "10022"
              },

              new EventLocation
              {
                Name = "Spangalang",
                AddressLine1 = "2736 Welton Street",
                City = "Denver",
                State = "CO",
                ZipCode = "80205"
              },

              new EventLocation
              {
                Name = "Katra Lounge & Event Space",
                AddressLine1 = "217 Bowery",
                City = "New York",
                State = "NY",
                ZipCode = "10002"
              },

              new EventLocation
              {
                Name = "Online",
                City = "Online"
              },
          };
        }
        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
          {
              new EventItem
              {
                EventCategoryId = 3,
                EventLocationId = 1,
                Title = "Seattle Mom Prom",
                Description = "An evening of drinks, desserts, dancing and FUN -- the ultimate ladies night out! All benefiting Perinatal Support Washington!",
                Price = 99.5M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/1",
                EventStartDateTime = new DateTime(2023,5,8,18,0,0),
                EventEndDateTime = new DateTime(2023,5,8,21,0,0),
                IsOnlineEvent = false
              },


              new EventItem
              {
                EventCategoryId = 2,
                EventLocationId = 2,
                Title = "Tech Career Fair",
                Description = "Seattle Tech Career Fair: Exclusive Tech Hiring Event",
                Price = 0.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/2",
                EventStartDateTime = new DateTime(2023,5,23,9,0,0),
                EventEndDateTime = new DateTime(2023,5,23,18,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 1,
                EventLocationId = 2,
                Title = "MCS Night at the Races",
                Description = "Join fellow MCS Families for a special night at the races. This TAPP event helps raise funds to support our students and teachers.",
                Price = 20.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/3",
                EventStartDateTime = new DateTime(2023,6,12,18,0,0),
                EventEndDateTime = new DateTime(2023,6,12,21,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 1,
                EventLocationId = 4,
                Title = "Ancient drumming workshop with Heilung’s Jacob Lund",
                Description = "Explore the ancient art of drumming with Denmark’s Jacob Lund, of the band Heilung",
                Price = 130.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/4",
                EventStartDateTime = new DateTime(2023,5,26,17,0,0),
                EventEndDateTime = new DateTime(2023,5,26,20,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 2,
                EventLocationId = 5,
                Title = "Venice is Sinking Masquerade Ball 2023",
                Description = "Venice is Sinking Masquerade Ball ~ NEW VENUE!",
                Price = 15.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/5",
                EventStartDateTime = new DateTime(2023,5,20,9,0,0),
                EventEndDateTime = new DateTime(2023,5,21,1,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 2,
                EventLocationId = 6,
                Title = "Family Magic Show at the Seattle Center",
                Description = "Family Friendly Magic Show at the Seattle Center. Free Admission. Artful theatrical magic to amaze and entertain kids and adults.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/6",
                EventStartDateTime = new DateTime(2023,4,29,13,0,0),
                EventEndDateTime = new DateTime(2023,4,29,13,45,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 3,
                EventLocationId = 7,
                Title = "Empress Yacht July 4th Fireworks Party Cruise",
                Description = "A July 4th party cruise aboard the Empress yacht with a panoramic view of the San Francisco skyline under the stars and city lights",
                Price = 169.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/7",
                EventStartDateTime = new DateTime(2023,7,4,19,30,0),
                EventEndDateTime = new DateTime(2023,7,4,11,45,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 4,
                EventLocationId = 8,
                Title = "SOUND BATH IN REDWOOD GROVE - GOLDEN GATE PARK",
                Description = "The Logos Method ~ SOUND BATH ~ APRIL 29, 2022",
                Price = 40.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/8",
                EventStartDateTime = new DateTime(2023,4,29,15,0,0),
                EventEndDateTime = new DateTime(2023,4,29,16,30,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 5,
                EventLocationId = 16,
                Title = "Come Meet A Black Person - Anti-Racism Virtual Series",
                Description = "Come Meet A Black Person - anti-racism virtual event where non-Blacks talk about racism and eradicating racism with Blacks.",
                Price = 200.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/9",
                EventStartDateTime = new DateTime(2023,5,14,12,0,0),
                EventEndDateTime = new DateTime(2023,5,14,14,0,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 9,
                Title = "Network After Work: Denver at The Infinite Monkey Theorem",
                Description = "Network After Work invites you to an evening out with other local business owners, entrepreneurs, executives, and career-minded professionals.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/10",
                EventStartDateTime = new DateTime(2023,5,17,18,0,0),
                EventEndDateTime = new DateTime(2023,5,17,20,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 1,
                Title = "John Fisher's Breakfast Club (from Invest Success)",
                Description = "Come join us for the best real estate investor networking in town. We have room for up to 80 people, so get your ticket early!",
                Price = 30.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/11",
                EventStartDateTime = new DateTime(2023,6,10,7,0,0),
                EventEndDateTime = new DateTime(2023,6,10,10,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 10,
                Title = "Deal Exchange",
                Description = "Real Estate Professional Networking Affair",
                Price = 12.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/12",
                EventStartDateTime = new DateTime(2023,5,8,19,0,0),
                EventEndDateTime = new DateTime(2023,5,8,21,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 11,
                Title = "NYC Blockchain Network Meetup",
                Description = "The monthly meetup for the NYC crypto and blockchain community.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/13",
                EventStartDateTime = new DateTime(2023,5,18,17,0,0),
                EventEndDateTime = new DateTime(2023,5,18,21,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 12,
                Title  = "Multifamily Real Estate Networking Event",
                Description = "Join us on Saturday morning (5/19) in midtown NYC to network with other multifamily real estate investors.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/14",
                EventStartDateTime = new DateTime(2023,5,13,10,0,0),
                EventEndDateTime = new DateTime(2023,5,13,12,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 16,
                Title = "New York Tech Career Fair: Exclusive Tech Hiring Event",
                Description = "Tech Career Fair focus on helping companies achieve their diversity and inclusivity initiative with more diverse non-traditional candidates.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/15",
                EventStartDateTime = new DateTime(2023,5,19,12,0,0),
                EventEndDateTime = new DateTime(2023,5,19,15,0,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 16,
                Title = "Diversity, Equity & Inclusion Conversations - Everybody At The Table",
                Description = "DE&I perspectives are intended to recognize and complement our history and leverage our inherent qualities, both personal and in business.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/16",
                EventStartDateTime = new DateTime(2023,5,10,11,0,0),
                EventEndDateTime = new DateTime(2023,5,10,12,0,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 16,
                Title = "Business Planning for Small Business",
                Description= "Learn all about business planning to put your best foot forward when developing your small business or start-up.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/17",
                EventStartDateTime = new DateTime(2023,6,21,10,0,0),
                EventEndDateTime = new DateTime(2023,6,21,12,0,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 16,
                Title = "Small Business Spotlight Networking Meeting",
                Description = "Come business network with us and have fun! First and Third Thursdays, at noon central, 1pm eastern Sponsorship available",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/18",
                EventStartDateTime = new DateTime(2023,5,18,13,0,0),
                EventEndDateTime = new DateTime(2023,5,18,14,0,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 16,
                Title = "Business Plan 101",
                Description = "Learn why a business plan is important for your business success and the steps to complete your own!",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/19",
                EventStartDateTime = new DateTime(2023,5,25,10,0,0),
                EventEndDateTime = new DateTime(2023,5,25,11,30,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 6,
                EventLocationId = 16,
                Title = "WEBINAR: TikTok for Small Business",
                Description = "TikTok for Small Business Webinar",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/20",
                EventStartDateTime = new DateTime(2023,5,9,19,0,0),
                EventEndDateTime = new DateTime(2023,5,9,20,30,0),
                IsOnlineEvent = true
              },

              new EventItem
              {
                EventCategoryId = 7,
                EventLocationId = 2,
                Title = "Foxtrot",
                Description = "Come dance the night away with talent from local furry DJ's, fursuits, drinks, and food at Denver Sweet!",
                Price = 6.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/21",
                EventStartDateTime = new DateTime(2023,5,27,21,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 7,
                EventLocationId = 12,
                Title = "'Friendly Fire' Game Night & Collab with Dominican Republic and St. Martin",
                Description = "Join us at Leaves of Three for a night of painting, planting & sipping complimentary cocktails! (for those over 21 years)",
                Price = 45.0M,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/22",
                EventStartDateTime = new DateTime(2023,5,12,18,3,30,0),
                EventEndDateTime = new DateTime(2023,5,12,20,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 7,
                EventLocationId = 13,
                Title = "Happy Hour Taste of Tarot",
                Description = "Free Learn to Read Tarot Cards event. This event is for beginners.",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/23",
                EventStartDateTime = new DateTime(2023,5,27,17,0,0),
                EventEndDateTime = new DateTime(2023,5,27,19,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 7,
                EventLocationId = 14,
                Title = "'Friendly Fire' Game Night & Collab with Dominican Republic and St. Martin",
                Description = "Join us for 'Friendly Fire' a series of casual gaming events for everyone. Play over 100+ games on PC and Xbox, meet new people & giveaways!",
                Price = 0,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/24",
                EventStartDateTime = new DateTime(2023,5,13,14,0,0),
                EventEndDateTime = new DateTime(2023,5,13,18,0,0),
                IsOnlineEvent = false
              },

              new EventItem
              {
                EventCategoryId = 7,
                EventLocationId = 15,
                Title = "Kaleidoscope: Poetic Forms and Collective Histories",
                Description = "A conversation with leading poets including Monica Youn and Courtney Faye Taylor, and moderator Doug Kearney",
                Price = 26,
                PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/25",
                EventStartDateTime = new DateTime(2023,5,13,14,0,0),
                IsOnlineEvent = false
              },
          };
        }
    }
}
