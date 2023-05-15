using Microsoft.AspNetCore.Mvc;

namespace EventsWebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class EventCatalog
        {
            public static string GetAllEventItems(string baseUrl,int page, int take)
            {
               
                return $"{baseUrl}/EventItems?pageIndex={page}&pageSize={take}";
               

            }
            public static string GetAllEventCategories(string baseUri)
            {
                return $"{baseUri}/EventCategories";
            }


            public static string GetFilteredEventItems(string baseUri,
               int? EventId, int? EventCategoryId, bool? IsOnline, int? city, int page, int take)
            {   
                var preUri = string.Empty;
                var filterQS = string.Empty;
                


            }

        }
       
    }
}
