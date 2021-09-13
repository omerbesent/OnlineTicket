using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Event : IEntity
    {
        public int EventId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        [ForeignKey("PlaceId")]
        public int? PlaceId { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? Date { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Active { get; set; }


        public Place Place { get; set; }
        public Category Category { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<EventSelectedSeat> EventSelectedSeats { get; set; }
    }
}
