using Core;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EventDto : IDto
    {
        public int EventId { get; set; }
        public int CategoryId { get; set; }
        public int PlaceId { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public DateTime? Date { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public bool? Active { get; set; }
        public Session[] Sessions { get; set; }
        public IFormFile CoverPhoto { get; set; }
    }
}
