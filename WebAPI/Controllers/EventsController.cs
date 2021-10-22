using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
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
        //// Dependency chain -- bağımlılık zinciri IProductService ProductManager a ihtiyaç duyuyor. ProductManager da IProdutDal a ihtiyaç duyuyor .
        ///
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
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
            var result = _eventService.Get(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var result = _eventService.GetListByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Save([FromForm] EventDto eventDto)
        {
            var result = _eventService.Add(eventDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] EventDto eventDto)
        {
            var result = _eventService.Update(eventDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int eventId)
        {
            var result = _eventService.Delete(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("sendmail")]
        //public IActionResult SendMail()
        //{
        //    string filePath = string.Format("{0}\\MailTemplate\\Register.html", _hostingEnvironment.ContentRootPath);
        //    var htmlFile = System.IO.File.ReadAllText(filePath);
        //    //MailRequest mailRequest = new MailRequest();
        //    //mailRequest.ToEmail = "omer.besent@hotmail.com";
        //    //mailRequest.Subject = "Test email";
        //    //mailRequest.Body = "mail içerik";

        //    var result = _mailService.SendRegisterEmail("omer.besent@hotmail.com", "Omer Besent", htmlFile, "#");

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
