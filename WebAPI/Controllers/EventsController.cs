using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //// Dependency chain -- bağımlılık zinciri IProductService ProductManager a ihtiyaç duyuyor. ProductManager da IProdutDal a ihtiyaç duyuyor .
            var result = _eventService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int eventId)
        {
            //// Dependency chain -- bağımlılık zinciri IProductService ProductManager a ihtiyaç duyuyor. ProductManager da IProdutDal a ihtiyaç duyuyor .
            var result = _eventService.Get(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("save")]
        //public IActionResult Save(Event evnt, Session[] sessions)
        //{
        //    //// Dependency chain -- bağımlılık zinciri IProductService ProductManager a ihtiyaç duyuyor. ProductManager da IProdutDal a ihtiyaç duyuyor .
        //    var result = _eventService.Add(evnt,sessions);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
