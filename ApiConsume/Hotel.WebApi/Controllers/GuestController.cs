using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.GuestDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IService<Guest> _service;
        private readonly IMapper _mapper;

        public GuestController(IService<Guest> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Guests()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(Create_Guest_Dto create_Guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Guest>(create_Guest);
                await _service.AddAsync(model);

                return Ok();
            }

        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteRoom(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(Update_Guest_dto update_Guest_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Guest>(update_Guest_);
                await _service.UpdateAsync(model);
                return Ok();
            }
            



        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Guest(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
    }
}
