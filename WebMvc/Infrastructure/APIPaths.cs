namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUrl)
            {
                return $"{baseUrl}/eventcategories";
            }

            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}/eventlocations";
            }

            public static string GetAllEventItems(string baseUri, int page, int take, int? type, string? city)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;

                if (type.HasValue)
                {
                    filterQs = $"eventCategoryId={type.Value}";
                }

                if (!string.IsNullOrEmpty(city))
                {
                    filterQs = (filterQs == string.Empty)
                               ? $"city={city}" :
                               $"{filterQs}&city={city}";
                }

                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/items?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseUri}/items/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri;
            }
        }
    }
}

