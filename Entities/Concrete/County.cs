using Core.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class County : IEntity
    {
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public int CityId { get; set; }

        [JsonIgnore]
        public ICollection<Place> Places { get; set; }
    }
}
