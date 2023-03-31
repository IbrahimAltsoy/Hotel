using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
        private readonly IService<Room> _service;
		private readonly IMapper _mapper;

        public RoomController(IService<Room> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
		public async Task<IActionResult> Rooms()
		{
			var model = await _service.GetAllIsActiveTrueAsync();
			return Ok(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddRoom(AddRoomDto addRoomDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
                var model = _mapper.Map<Room>(addRoomDto);
                await _service.AddAsync(model);

                return Ok();
            }
			
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteRoomAsync(Guid id)
		{
            var model = await _service.GetByIdAsync(id);
            return Ok(await _service.SafeDeletedAsync(model));

        }
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRoom(UpdateRoomDto updateRoomDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
                var model = _mapper.Map<Room>(updateRoomDto);
                await _service.UpdateAsync(model);
                return Ok();
            }
			
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Room(Guid id)
		{
			var model = await _service.GetByIdAsync(id);
			return Ok(model);
		}
	}
}
