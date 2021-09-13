using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
