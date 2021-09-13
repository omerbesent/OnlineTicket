using Core.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        [JsonIgnore]
        public ICollection<Place> Places { get; set; }
    }
}
