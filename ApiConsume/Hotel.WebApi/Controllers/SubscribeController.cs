using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.DtoLayer.Dtos.SubscribeDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscribeController : ControllerBase
	{
        private readonly IService<Subscribe> _service;
        private readonly IMapper _mapper;

        public SubscribeController(IService<Subscribe> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Subscribes()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Subscribes(AddSubscribeDto subscribeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Subscribe>(subscribeDto);
                await _service.AddAsync(model);

                return Ok();
            }

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeletesubscribe(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updatesubscribe(UpdateSubscribeDto subscribe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Subscribe>(subscribe);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Subscribe(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
    }
}
