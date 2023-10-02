using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.BookingDto;
using Hotel.DtoLayer.Dtos.SubscribeDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IService<Booking> _service;
        private readonly IMapper _mapper;

        public BookingController(IService<Booking> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Bookings()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingDto addBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Booking>(addBooking);
                await _service.AddAsync(model);

                return Ok();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteBooking(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Booking>(updateBooking);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Booking(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
    }
}
