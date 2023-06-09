﻿using WebMvc.Models;

namespace WebMvc.Infrastructure
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
                string preUri = string.Empty;
                string filterQuery = string.Empty;

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

            public static string GetEvents(string baseurl, int page, int take, int? category, int? isOnline, string? city)
            {
                string preUri = string.Empty;
                string filterQuery = string.Empty;

                if (isOnline.HasValue)
                {
                    if (isOnline.Value == 2)
                    {
                        filterQuery += string.IsNullOrEmpty(filterQuery) ?
                                     $"IsOnline=true" : $"&IsOnline=true";
                    }
                    else
                    {
                        if (city != null)
                        {
                            filterQuery += string.IsNullOrEmpty(filterQuery) ? $"City={city}" : $"City={city}";
                        }
                    }
                }
                if (category.HasValue)
                {
                    filterQuery += string.IsNullOrEmpty(filterQuery) ?
                                 $"EventCategoryId={category}" : $"&EventCategoryId={category}";
                }


                if (string.IsNullOrEmpty(filterQuery))
                {
                    preUri = $"{baseurl}/EventItems?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseurl}/EventItems/filter?{filterQuery}&pageIndex={page}&pageSize={take}";
                }
                return preUri;

            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }


}
