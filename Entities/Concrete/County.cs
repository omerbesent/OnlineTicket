﻿using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class County : IEntity
    {
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public int CityId { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
