using EventsCatalogAPI.Data;
using EventsCatalogAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsCatalogAPI.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventsCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly EventContext _eventContext;
        private readonly IConfiguration _configuration;

        public EventController(EventContext eventContext, IConfiguration configuration)
        {
            _eventContext = eventContext;
            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventItems([FromQuery] int PageIndex = 0,
            [FromQuery] int PageSize = 3)
        {

            var local_items_count = await _eventContext.EventItems.LongCountAsync();
            var local_items = await _eventContext.EventItems
               .OrderBy(q => q.EventCategoryId)
               .Skip(PageIndex * PageSize)
               .Take(PageSize)
               .ToListAsync();
            local_items = ChangePictureUrl(local_items);
            var model = new PaginatedViewModel()
            {
                PageIndex = PageIndex,
                PageSize = local_items.Count,
                Data = local_items,
                Count = local_items_count
            };

            return Ok(model);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var list = await _eventContext.EventCategories.ToListAsync();
            return Ok(list);
        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> EventItems(
            [FromQuery] int? EventId,
            [FromQuery] int? EventCategoryId,
            [FromQuery] bool? IsOnline,
            [FromQuery] string? City,
            [FromQuery] int PageIndex=0,
            [FromQuery] int PageSize=3)
        {
            var query = (IQueryable<EventItem>)_eventContext.EventItems.Include(e => e.EventLocation);

            if (EventCategoryId.HasValue)
            {
                query = query.Where(q => q.EventCategoryId == EventCategoryId);
            }
            if(EventId.HasValue)
            {
                query = query.Where(q => q.EventCategoryId == EventId);
            }
            if (!string.IsNullOrEmpty(City))
            {
                query = query.Where(q => q.EventLocation.City == City);
            }
            if(IsOnline.HasValue)
            {
                if((bool)IsOnline)
                {
                    query = query.Where(q => q.IsOnline == IsOnline);
                }
            }
        
            var local_items_count = await query.LongCountAsync();
            var local_items = await query
                .OrderBy(q => q.EventCategoryId)
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToListAsync();

            local_items = ChangePictureUrl(local_items);

            var model = new PaginatedViewModel()
            {
                PageIndex = PageIndex,
                PageSize = local_items.Count,
                Data = local_items,
                Count = local_items_count
            };

            return Ok(model);

        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item => item.PictureUrl = item.PictureUrl
            .Replace("https://sampledomain",
            _configuration["ExternalBaseUrl"]));
            return items;
        }
    }
}
