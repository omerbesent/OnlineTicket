using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Session : IEntity
    {
        public int SessionId { get; set; }
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public string EventSession { get; set; }

        [JsonIgnore]
        public Event Event { get; set; }
    }
}
