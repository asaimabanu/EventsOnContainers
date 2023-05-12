namespace WebMVC.Infrastructure
{
    public static class APIPaths
    {
        public static class EventCatalog
        {
            public static string GetAllCategories(string baseurl)
            {
                return $"{baseurl}/EventCategories";
            }

            public static string GetEvents(string baseurl, int page, int take, int? category) 
            {
                string preUri = string.Empty ;
                string filterQuery = string.Empty ;

                if (category.HasValue)
                {
                    filterQuery = $"EventCategoryId={category}";
                }
                if (string.IsNullOrEmpty(filterQuery))
                {
                    preUri = $"{baseurl}/EventItems?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseurl}/EventItems/filter?pageIndex={page}&pageSize={take}&{filterQuery}";
                }
                return preUri;
                
            }
        }
    }
}
