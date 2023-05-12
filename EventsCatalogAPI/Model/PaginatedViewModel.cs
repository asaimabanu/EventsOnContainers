using EventsCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace EventsCatalogAPI.Model
{
    public class PaginatedViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<EventItem>? Data { get; set; }
        public long Count { get; set; }
    }

}
