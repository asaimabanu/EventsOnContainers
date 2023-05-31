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
              new EventCategory{Category = "Other"},
              new EventCategory{Category = "Business"},
              new EventCategory{Category = "Hobbies"},
              new EventCategory{Category = "Food & Drink"},
              new EventCategory{Category = "Sports & Fitness"}
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
                            /*
                             * EventShow = new EventShow
                             * {
                             *      ShowDate = DateTime.Now,
                             *      ShowTime = DateTime.Now,
                             *      TicketQuantity = 100
                             * }
                             * 
                             */
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
                          
              },
               new EventItem{EventCategoryId = 6,
                             Title = "Network After Work: Denver at The Infinite Monkey Theorem",
                             Description = "Network After Work invites you to an evening out with other local business owners, entrepreneurs, executives, and career-minded professionals.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/7",
                             EventStartDateTime = new DateTime(2023,5,17,18,0,0),
                             EventEndDateTIme = new DateTime(2023,5,17,20,0,0),
                             EventLocation= new EventLocation
                             {
                                 AddressLine1 = "The Infinite Monkey Theorem",
                                 AddressLine2 = "3200 Larimer Street",
                                 City = "Denver",
                                 State = "CO",
                                 ZipCode = "80205"
                             }
               },
               new EventItem{EventCategoryId = 6,
                             Title = "John Fisher's Breakfast Club (from Invest Success)",
                             Description = "Come join us for the best real estate investor networking in town. We have room for up to 80 people, so get your ticket early!",
                             Price = 30,
                             PictureUrl = "https://sampledomain/api/pic/8",
                             EventStartDateTime = new DateTime(2023,6,10,7,0,0),
                             EventEndDateTIme = new DateTime(2023,6,10,10,0,0),
                             EventLocation = new EventLocation
                             {
                                 AddressLine1 = "Dazzle at Baur's",
                                 AddressLine2 = "1512 Curtis Street",
                                 City = "Denver",
                                 State = "CO",
                                 ZipCode = "80202"
                             }
               },
               new EventItem{EventCategoryId = 6,
                             Title  = "Speed Networking Event",
                             Description = "Speed Networking Event in Denver. Come and meet business professionals at NeworkNite!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/9",
                             EventStartDateTime = new DateTime(2023,5,4,19,0,0),
                             EventEndDateTIme = new DateTime(2023,5,4,21,0,0),
                             EventLocation = new EventLocation
                             {
                                 AddressLine1 = "AC Bar and Kitchen",
                                 AddressLine2 = "750 15th Street",
                                 City = "Denver",
                                 State = "CO",
                                 ZipCode= "80202"
                             }
               },
               new EventItem{EventCategoryId = 6,
                             Title = "Deal Exchange",
                             Description = "Real Estate Professional Networking Affair",
                             Price = 12,
                             PictureUrl = "https://sampledomain/api/pic/9",
                             EventStartDateTime = new DateTime(2023,5,8,19,0,0),
                             EventEndDateTIme = new DateTime(2023,5,8,21,0,0),
                             EventLocation = new EventLocation 
                             {
                                AddressLine1 = "Mykonos Blue Rooftop",
                                AddressLine2 = "127 W 28th Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10001"
                             }
               },
               new EventItem{EventCategoryId = 6,
                             Title = "NYC Blockchain Network Meetup",
                             Description = "The monthly meetup for the NYC crypto and blockchain community.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/10",
                             EventStartDateTime = new DateTime(2023,5,18,17,0,0),
                             EventEndDateTIme = new DateTime(2023,5,18,21,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Yara",
                                AddressLine2 = "319 E 53rd Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10022"
                             }
               },
               new EventItem{EventCategoryId = 6,
                             Title  = "Multifamily Real Estate Networking Event",
                             Description = "Join us on Saturday morning (5/19) in midtown NYC to network with other multifamily real estate investors.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/11",
                             EventStartDateTime = new DateTime(2023,5,13,10,0,0),
                             EventEndDateTIme = new DateTime(2023,5,13,12,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "151 West 30th Street",
                                AddressLine2 = "3rd Floor",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10001"
                             }
               },
               new EventItem{EventCategoryId = 6,
                             Title = "New York Tech Career Fair: Exclusive Tech Hiring Event",
                             Description = "Tech Career Fair focus on helping companies achieve their diversity and inclusivity initiative with more diverse non-traditional candidates.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/12",
                             EventStartDateTime = new DateTime(2023,5,19,12,0,0),
                             EventEndDateTIme = new DateTime(2023,5,19,15,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 6,
                             Title = "Diversity, Equity & Inclusion Conversations - Everybody At The Table",
                             Description = "DE&I perspectives are intended to recognize and complement our history and leverage our inherent qualities, both personal and in business.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/13",
                             EventStartDateTime = new DateTime(2023,5,10,11,0,0),
                             EventEndDateTIme = new DateTime(2023,5,10,12,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 6,
                             Title = "Business Planning for Small Business",
                             Description= "Learn all about business planning to put your best foot forward when developing your small business or start-up.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/14",
                             EventStartDateTime = new DateTime(2023,6,21,10,0,0),
                             EventEndDateTIme = new DateTime(2023,6,21,12,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 6,
                             Title = "Small Business Spotlight Networking Meeting",
                             Description = "Come business network with us and have fun! First and Third Thursdays, at noon central, 1pm eastern Sponsorship available",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/15",
                             EventStartDateTime = new DateTime(2023,5,18,13,0,0),
                             EventEndDateTIme = new DateTime(2023,5,18,14,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 6,
                             Title = "Business Plan 101",
                             Description = "Learn why a business plan is important for your business success and the steps to complete your own!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/16",
                             EventStartDateTime = new DateTime(2023,5,25,10,0,0),
                             EventEndDateTIme = new DateTime(2023,5,25,11,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 6,
                             Title = "WEBINAR: TikTok for Small Business",
                             Description = "TikTok for Small Business Webinar",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/17",
                             EventStartDateTime = new DateTime(2023,5,9,19,0,0),
                             EventEndDateTIme = new DateTime(2023,5,9,20,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Foxtrot",
                             Description = "Come dance the night away with talent from local furry DJ's, fursuits, drinks, and food at Denver Sweet!",
                             Price = 6,
                             PictureUrl = "https://sampledomain/api/pic/18",
                             EventStartDateTime = new DateTime(2023,5,27,21,0,0),
                             EventLocation = new EventLocation 
                             {
                                AddressLine1 = "Denver Sweet",
                                AddressLine2 = "776 Lincoln Street",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80203"
                             }
                             
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Paint, Plant & Sip",
                             Description = "Join us at Leaves of Three for a night of painting, planting & sipping complimentary cocktails! (for those over 21 years)",
                             Price = 45,
                             PictureUrl = "https://sampledomain/api/pic/19",
                             EventStartDateTime = new DateTime(2023,5,12,18,3,30,0),
                             EventEndDateTIme = new DateTime(2023,5,12,20,0,0),
                             EventLocation= new EventLocation 
                             {
                                AddressLine1 = "1600 Boulder Street",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80211"
                             }
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Happy Hour Taste of Tarot",
                             Description = "Free Learn to Read Tarot Cards event. This event is for beginners.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/20",
                             EventStartDateTime = new DateTime(2023,5,27,17,0,0),
                             EventEndDateTIme = new DateTime(2023,5,27,19,0,0),
                             EventLocation = new EventLocation 
                             {
                                AddressLine1 = "The Hornet",
                                AddressLine2 = "76 Broadway",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80203"
                             }
               },
               new EventItem{EventCategoryId = 7,
                             Title = "'Friendly Fire' Game Night & Collab with Dominican Republic and St. Martin",
                             Description = "Join us for 'Friendly Fire' a series of casual gaming events for everyone. Play over 100+ games on PC and Xbox, meet new people & giveaways!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/21",
                             EventStartDateTime = new DateTime(2023,5,13,14,0,0),
                             EventEndDateTIme = new DateTime(2023,5,13,18,0,0),
                             EventLocation = new EventLocation 
                             {
                                AddressLine1 = "Microsoft Experience Center (3rd and 5th Floors)",
                                AddressLine2 = "677 5th Avenue",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10022"
                             }
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Kaleidoscope: Poetic Forms and Collective Histories",
                             Description = "A conversation with leading poets including Monica Youn and Courtney Faye Taylor, and moderator Doug Kearney",
                             Price = 26,
                             PictureUrl = "https://sampledomain/api/pic/22",
                             EventStartDateTime = new DateTime(2023,5,13,14,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Lillian Vernon Creative Writers House",
                                AddressLine2 = "58 West 10th Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10003"
                             }
               },
               new EventItem{EventCategoryId = 7,
                             Title= "Water Color Workshops",
                             Description = "Join NYC Parks and The Art Students League for a series of watercolor workshops.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/23",
                             EventStartDateTime = new DateTime(2023,5,10,18,0,0),
                             EventEndDateTIme = new DateTime(2023,5,10,20,0,0),
                             EventLocation = new EventLocation 
                             {
                                AddressLine1 = "Hamilton Fish Recreation Center",
                                AddressLine2 = "128 Pitt Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10002"
                             }
               },
               new EventItem{EventCategoryId = 7,
                             Title = "One Piece Card Game - Online Treasure Cup [Oceania]",
                             Description = "TAK Games are proud to support the upcoming One Piece Card Game via a Premier TO Online Tournament Event",
                             Price = 60,
                             PictureUrl = "https://sampledomain/api/pic/24",
                             EventStartDateTime = new DateTime(2023,5,19,7,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Online Drawing Workshop: Hedgehog",
                             Description = "Join in with us with this mindful art session where you will have the freedom and support to unwind and get creative in a series of guided drawing",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/25",
                             EventStartDateTime = new DateTime(2023,5,16,13,30,0),
                             EventEndDateTIme = new DateTime(2023,5,16,14,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 7,
                             Title = "How to Draw Musical Instruments!",
                             Description = "Join Emily as she shows you how to draw a Musical instrument!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/26",
                             EventStartDateTime = new DateTime(2023,5,24,14,0,0),
                             EventEndDateTIme = new DateTime(2023,5,24,17,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Shibori Indigo Tie Dye for Beginners Virtual Workshop",
                             Description = "An online workshop: Learn Shibori and tie dye folding techniques, and about mixing up a vat of pre-reduced indigo",
                             Price = 35,
                             PictureUrl = "https://sampledomain/api/pic/27",
                             EventStartDateTime = new DateTime(2023,5,13,13,0,0),
                             EventEndDateTIme = new DateTime(2023,5,13,15,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 7,
                             Title = "NATURAL DYEING: On Fabric",
                             Description = "In this online class, you will learn a few natural dyeing techniques that you can do at home!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/28",
                             EventStartDateTime = new DateTime(2023,5,20,9,0,0),
                             EventEndDateTIme = new DateTime(2023,5,20,10,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 7,
                             Title = "Intro to Textural Embroidery",
                             Description = "Join us and learn to sew textured embroidery stitches!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/29",
                             EventStartDateTime = new DateTime(2023,5,9,13,0,0),
                             EventEndDateTIme = new DateTime(2023,5,9,14,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 8,
                             Title = "10th Annual Whiskey + Doughnuts",
                             Description = "Enjoy some of Colorado's best distilleries and doughnut bakeries, all local favorites, at this one-of-a-kind event.",
                             Price = 50,
                             PictureUrl = "https://sampledomain/api/pic/30",
                             EventStartDateTime = new DateTime(2023,6,17,14,0,0),
                             EventEndDateTIme = new DateTime(2023,6,17,17,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Auraria Campus",
                                AddressLine2 = "1201 5th Street",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80204"
                             }
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Belgian Brew Fest 2023",
                             Description = "Enjoy the best Belgian-style beers the region has to offer. Hand-picked breweries and an entry ticket cap sell this festival out yearly.",
                             Price = 48,
                             PictureUrl = "https://sampledomain/api/pic/31",
                             EventStartDateTime = new DateTime(2023,6,3,13,0,0),
                             EventEndDateTIme = new DateTime(2023,6,3,16,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Bruz Beers",
                                AddressLine2 = "1675 West 67th Avenue",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80221"
                             }
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Passa Passa Caribbean Party!",
                             Description = "The best Caribbean party in the city! Fusing the best of Caribbean music with great food and atmosphere, what more could you ask for!",
                             Price = 15,
                             PictureUrl = "https://sampledomain/api/pic/32",
                             EventStartDateTime = new DateTime(2023,6,14,21,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Spangalang",
                                AddressLine2 = "2736 Welton Street",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80205"
                             }
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Great Wines of the World 2023: New York Grand Tasting",
                             Description = "New York, ARE YOU READY? JamesSuckling.com returns to the Big Apple with a brand new Grand Tasting featuring 195 iconic wine producers.",
                             Price = 10,
                             PictureUrl = "https://sampledomain/api/pic/33",
                             EventStartDateTime = new DateTime(2023,6,16,16,30,0),
                             EventEndDateTIme = new DateTime(2023,6,16,20,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "The Altman Building",
                                AddressLine2 = "135 West 18th Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10011"
                             }
               },
               new EventItem{EventCategoryId = 8,
                             Title = "UPTOWN NIGHT MARKET",
                             Description = "NYC's largest food & culture event",
                             Price = 7,
                             PictureUrl = "https://sampledomain/api/pic/34",
                             EventStartDateTime = new DateTime(2023,7,13,16,0,0),
                             EventEndDateTIme = new DateTime(2023,7,13,22,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "West 133rd Street & 12th Avenue",
                                AddressLine2 = "701 W 133rd Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10027"
                             }
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Free Drinks Caribbean Thursdays at Katra NYC!!",
                             Description = "Hottest Caribbean Thursdays after work to hit NYC",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/35",
                             EventStartDateTime = new DateTime(2023,6,22,18,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Katra Lounge & Event Space",
                                AddressLine2 = "217 Bowery",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10002"
                             }
               },
               new EventItem{EventCategoryId = 8,
                             Title = "The Taste of Jewish Culture",
                             Description = "Join us for an online exploration of Jewish food traditions and their historical connections with Jewish Food researcher Joel Haber",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/36",
                             EventStartDateTime = new DateTime(2023,6,14,19,0,0),
                             EventEndDateTIme = new DateTime(2023,6,14,20,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 8,
                             Title = "FREE Virtual Cooking Class: Cedar Plank Salmon with Orzo Tabouli",
                             Description = "FREE Interactive Online Cooking Class - Cedar Plank Salmon with Orzo Tabouli",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/37",
                             EventStartDateTime = new DateTime(2023,5,16,19,0,0),
                             EventEndDateTIme = new DateTime(2023,5,16,20,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Plant-based cheese school with Chef Adam Sobel",
                             Description = "A completely donation-based cooking class will conquer the vegan cheese-making galaxy!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/38",
                             EventStartDateTime = new DateTime(2023,5,13,16,0,0),
                             EventEndDateTIme = new DateTime(2023,5,13,17,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Summer Pizza Party with Peter Reinhart",
                             Description = "Join guest chef",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/39",
                             EventStartDateTime = new DateTime(2023,5,23,18,0,0),
                             EventEndDateTIme = new DateTime(2023,5,23,19,15,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 8,
                             Title = "NCD Food Preservation Series: Freezing",
                             Description = "Online series on the basics of food preservation!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/40",
                             EventStartDateTime = new DateTime(2023,5,16,18,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 8,
                             Title = "Food as Medicine: Nutrition and Bone Health (Webinar)",
                             Description = "Join us in-person or watch along live online for a special Food as Medicine cooking program, focused on foods to support healthy bones.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/41",
                             EventStartDateTime = new DateTime(2023,5,16,11,0,0),
                             EventEndDateTIme = new DateTime(2023,5,16,12,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Denver Roller Derby Doubleheader",
                             Description = "Two roller derby games for the price of one. Come watch our juniors and our adult home teams play in this doubleheader",
                             Price = 15,
                             PictureUrl = "https://sampledomain/api/pic/42",
                             EventStartDateTime = new DateTime(2023,5,13,17,0,0),
                             EventEndDateTIme = new DateTime(2023,5,13,22,30,0), 
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Rollerdome: Home of Denver Roller Derby and Rocky Mountain Rollergirls",
                                AddressLine2 = "2375 South Delaware Street",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80223"
                             }
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Run for the Ribs 5k | Denver Q BBQ Fest | Empower Field | Memorial Weekend",
                             Description = "Join us for the Run for the Ribs 5k run. This event is part of the 2023 Denver Q BBQ Fest at Empower Field at Mile High",
                             Price = 45,
                             PictureUrl = "https://sampledomain/api/pic/43",
                             EventStartDateTime = new DateTime(2023,5,28,11,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Empower Field at Mile High",
                                AddressLine2 = "1701 Bryant Street",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80204"
                             }
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Spring Family Mountain Bike Day",
                             Description = "Join us for our Mountain Bike Day. Reserve for a time to ride.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/44",
                             EventStartDateTime = new DateTime(2023,5,20,10,0,0),
                             EventEndDateTIme = new DateTime(2023,5,20,14,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Ruby Hill Bike Park",
                                AddressLine2 = "West Jewell Avenue",
                                City = "Denver",
                                State = "CO",
                                ZipCode = "80223"
                             }
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Chelsea Piers Fitness Yoga Class",
                             Description = "A free yoga class for people who want to improve or get back into a regular practice.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/45",
                             EventStartDateTime = new DateTime(2023,6,22,7,0,0),
                             EventEndDateTIme = new DateTime(2023,6,22,8,0,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Chelsea Market",
                                AddressLine2 = "450 West 16th Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10011"
                             }
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Paragon Run Club x New Balance Sponsored Run",
                             Description = "Pre-Brooklyn Half Shakeout Run with New Balance! Demo Shoes, Post-Run Raffles, Pizaa, & Beer on Tap!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/46",
                             EventStartDateTime = new DateTime(2023,5,16,18,30,0),
                             EventEndDateTIme = new DateTime(2023,5,16,20,30,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Paragon Sports",
                                AddressLine2 = "867 Broadway",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10003"
                             }
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Sunrise IronStrength Bootcamp in Central Park with ASICS",
                             Description = "Spring Sunrise IronStrength Bootcamp in Central Park! Let's kick off spring with some sweat and smiles!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/47",
                             EventStartDateTime = new DateTime(2023,5,17,6,30,0),
                             EventEndDateTIme = new DateTime(2023,6,17,7,30,0),
                             EventLocation = new EventLocation
                             {
                                AddressLine1 = "Delacorte Theater",
                                AddressLine2 = "81 Central Park West",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10023"
                             }
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Fearless Dance Fitness and Toning Class",
                             Description = "Fearless virtual group fitness class where dance fitness and strength training meet for a total body workout!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/48",
                             EventStartDateTime = new DateTime(2023,7,3,10,30,0),
                             EventEndDateTIme = new DateTime(2023,7,3,11,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 9,
                             Title = "DSEP Network & Learn - Supporting athletes from ethnic minority groups",
                             Description = "The DSEP Network and Learn Series are events that bring together sport and exercise psychologists at all levels of their training and careers",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/49",
                             EventStartDateTime = new DateTime(2023,5,25,13,0,0),
                             EventEndDateTIme = new DateTime(2023,5,25,14,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Online Child Wellbeing and Protection in Sport (CWPS) Workshop",
                             Description = "Online Child Wellbeing and Protection in Sport (CWPS) Workshop",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/50",
                             EventStartDateTime = new DateTime(2023,5,22,13,0,0),
                             EventEndDateTIme = new DateTime(2023,5,22,16,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 9,
                             Title = "LGBTQ+ Inclusion in Recreational Cricket - First steps for clubs",
                             Description = "We all want cricket to be as inclusive as possible, but how do you make our clubs welcoming for the LGBTQ+ community - join us to find out!",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/51",
                             EventStartDateTime = new DateTime(2023,6,15,14,30,0),
                             EventEndDateTIme = new DateTime(2023,6,15,16,0,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Wild Camping 101 (online)",
                             Description = "If you'd love to try wild camping but don't know where to start, sign-up to our tips and tricks for enjoyable and responsible wild-camping.",
                             Price = 15,
                             PictureUrl = "https://sampledomain/api/pic/52",
                             EventStartDateTime = new DateTime(2023,5,24,14,30,0),
                             EventEndDateTIme = new DateTime(2023,5,24,15,30,0),
                             IsOnline = true
               },
               new EventItem{EventCategoryId = 9,
                             Title = "Intro to E-Biking Webinar",
                             Description = "This introductory workshop is designed to provide you with useful tips for buying, riding, and caring for your e-bike.",
                             Price = 0,
                             PictureUrl = "https://sampledomain/api/pic/53",
                             EventStartDateTime = new DateTime(2023,6,1,15,0,0),
                             EventEndDateTIme = new DateTime(2023,6,1,16,0,0),
                             IsOnline = true
               }
          };
        }
    }
}
