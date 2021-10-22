using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        ICountyService _countyService;
        public CountyController(ICountyService countyService)
        {
            _countyService = countyService;
        }

        [HttpGet("getallbycityid")]
        public IActionResult GetAllByCityId(int cityId)
        {
            var result = _countyService.GetListByCityId(cityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
