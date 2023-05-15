﻿using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();

        Task<EventCatalog> GetEventcatalogItemAsync(int page, int take, int? category);
    }
}