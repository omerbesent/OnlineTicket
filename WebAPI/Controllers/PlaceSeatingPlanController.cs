using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceSeatingPlanController : ControllerBase
    {
        IPlaceSeatingPlanService _placeSeatingPlanService;
        public PlaceSeatingPlanController(IPlaceSeatingPlanService placeSeatingPlanService)
        {
            _placeSeatingPlanService = placeSeatingPlanService;
        }

        [HttpGet("get")]
        public IActionResult Get(int placeSeatingPlanId)
        {
            var result = _placeSeatingPlanService.Get(placeSeatingPlanId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getplaceseats")]
        public IActionResult GetPlaceSeats(int placeId)
        {
            var result = _placeSeatingPlanService.GetByPlace(placeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PlaceSeatingPlan placeSeatingPlan)
        {
            var result = _placeSeatingPlanService.Add(placeSeatingPlan);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int placeSeatingPlan)
        {
            var result = _placeSeatingPlanService.Delete(placeSeatingPlan);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteByPlaceId(int placeId)
        {
            var deleted = _placeSeatingPlanService.GetByPlace(placeId);
            var result = _placeSeatingPlanService.DeleteAll(deleted.Data.ToArray());
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
