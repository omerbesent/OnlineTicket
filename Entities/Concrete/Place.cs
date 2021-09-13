using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Place : IEntity
    {
        public int PlaceId { get; set; }
        public string Title { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        [ForeignKey("CountyId")]
        public int CountyId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }

        [JsonIgnore]
        public City City { get; set; }
        [JsonIgnore]
        public County County { get; set; }
        [JsonIgnore]
        public ICollection<Event> Events { get; set; }

        //CreatedBy ve UpdatedBy dan daha sonra int? yerine int olacak
    }
}
