using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventService _eventService;
        IMailService _mailService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public EventsController(IEventService eventService, IMailService mailService, IHostingEnvironment hostingEnvironment)
        {
            _eventService = eventService;
            _mailService = mailService;
            _hostingEnvironment = hostingEnvironment;
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
            string filePath = string.Format("{0}\\MailTemplate\\Register.html", _hostingEnvironment.ContentRootPath);
            var htmlFile = System.IO.File.ReadAllText(filePath);
            //MailRequest mailRequest = new MailRequest();
            //mailRequest.ToEmail = "omer.besent@hotmail.com";
            //mailRequest.Subject = "Test email";
            //mailRequest.Body = "mail içerik";

            var result = _mailService.SendRegisterEmail("omer.besent@hotmail.com", "Omer Besent", htmlFile, "#");

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
