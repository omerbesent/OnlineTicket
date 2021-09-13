using OnlineTicket.Core.Entities;
using System;

namespace OnlineTicket.Entities.Concrete
{
    public class UserSelectedSeat : IEntity
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int? UserId { get; set; }
        public int EventId { get; set; }
        public string Session { get; set; }
        public string Seat { get; set; }
        public DateTime ProcessDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int SessionDeletionTime { get; set; }
        public decimal? EventPrice { get; set; }
    }
}
