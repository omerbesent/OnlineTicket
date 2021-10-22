using Core;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class PosterDto : IDto
    {
        public int PosterId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Active { get; set; }
        public IFormFile WebImage { get; set; }
        public IFormFile MobilImage { get; set; }
    }
}
