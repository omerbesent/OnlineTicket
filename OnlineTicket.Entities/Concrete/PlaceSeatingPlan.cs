using OnlineTicket.Core.Entities;

namespace OnlineTicket.Entities.Concrete
{
    public class PlaceSeatingPlan : IEntity
    {
        public int PlaceSeatingPlanId { get; set; }
        public int PlaceId { get; set; }
        public string RowCode { get; set; }
        public string Seats { get; set; }
        public int? Ranking { get; set; }
    }
}