using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Poster : IEntity
    {
        public int PosterId { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string MobileFileName { get; set; }
        public string FullPath { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public int Ranking { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
