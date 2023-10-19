using Hotel.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStuffService _stuffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetController(IStuffService stuffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _stuffService = stuffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }
        [HttpGet("StuffCount")]
        public IActionResult GetStuffCount()
        {
            
            return Ok(_stuffService.StuffCount());
        }
        
        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {

            return Ok(_bookingService.GetBookingCount());
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {

            return Ok(_appUserService.AppUserCount());
        }
        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {

            return Ok(_roomService.RoomCount());
        }
        [HttpGet("BookingSixtList")]
        public IActionResult BookingSixtList()
        {
            var model =  _bookingService.BookingSixtList();

            return Ok(model);
        }
    }
}
