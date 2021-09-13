using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventService _eventService;
        public EventsController(IEventService  eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //// Dependency chain -- bağımlılık zinciri IProductService ProductManager a ihtiyaç duyuyor. ProductManager da IProdutDal a ihtiyaç duyuyor .
            //IProductService productService = new ProductManager(new EfProductDal());

            var result = _eventService.GetAll();
            return Ok(result);
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            return BadRequest(result);
        }
    }
}
