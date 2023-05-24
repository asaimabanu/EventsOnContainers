using EventsCatalogAPI.Data;
using EventsCatalogAPI.Domain;
using EventsCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data;

namespace EventsCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;

        private readonly IConfiguration _config;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var categories = await _context.EventCategories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.Select(x => x.City).Distinct().Select(x => new { city = x }).ToListAsync();
            return Ok(locations);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                                    .OrderBy(c => c.Id)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Data = items,
                Count = itemsCount
            };

            return Ok(model);

        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Items(
            [FromQuery] int? eventCategoryId,
            [FromQuery] string? city,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemQuery = (IQueryable<EventItem>)_context.EventItems;
            var ids = new List<int>();

            //var locationquery = (IQueryable<EventLocation>)_context.EventLocations;

            if (eventCategoryId.HasValue)
            {
                itemQuery = itemQuery.Where(e => e.EventCategoryId == eventCategoryId.Value);
            }

            if (!string.IsNullOrEmpty(city))
            {

                //locationquery = locationquery.Where(l => l.City == city);   
                var query =
                        from locations in _context.EventLocations
                        where locations.City == city
                        select locations.Id;

                ids = query.ToList();

                if (ids.Count > 0)
                {
                    itemQuery = itemQuery.Where(e => ids.Contains(e.EventLocationId));
                }
            }

            //foreach (var id in ids)
            //{
            //    itemQuery = itemQuery.Where(e => e.EventLocationId == id);
            //}



            //var ids = locationQuery.Cast<DataColumn>()
            //                     .Select(x => x.ColumnName)
            //                     .ToArray();

            //var combineQuery = itemQuery
            //                  .Join
            //                  (
            //                    locationQuery,
            //                    e => e.EventLocationId,
            //                    l => l.Id,
            //                    (e, l) => new { EventItem = e, EventLocation = l }
            //                  );

            //var combineQuery = from e in itemQuery
            //                   join l in locationQuery
            //                   on e.EventLocationId equals l.Id into grouping
            //                   from l in grouping.DefaultIfEmpty()
            //                   select new { e, l };

            var itemsCount = await itemQuery.LongCountAsync();
            var items = await itemQuery
                                    .OrderBy(e => e.Id)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Data = items,
                Count = itemsCount
            };

            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item => item.PictureUrl = item.PictureUrl
                        .Replace("http://externaleventbaseurltobereplaced",
                         _config["ExternalBaseUrl"]));
            return items;
        }
    }
}
