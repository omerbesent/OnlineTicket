using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class EventSelectedSeat : IEntity
    {
        public int EventSelectedSeatId { get; set; }
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public string Seat { get; set; }
        public int? Ranking { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }

        public Event Event { get; set; }
    }
}
