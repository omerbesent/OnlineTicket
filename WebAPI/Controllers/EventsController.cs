using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventService _eventService;
        IMailService _mailService;
        public EventsController(IEventService eventService, IMailService mailService)
        {
            _eventService = eventService;
            _mailService = mailService;
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

        [HttpGet("sendmail")]
        public IActionResult SendMail()
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = "omer.besent@hotmail.com";
            mailRequest.Subject = "Test email";
            mailRequest.Body = "mail içerik";

            _mailService.SendEmailAsync(mailRequest);

            return Ok("Mail gönderildi");
           
        }

    }
}
