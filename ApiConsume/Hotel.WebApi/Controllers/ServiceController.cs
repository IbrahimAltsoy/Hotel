using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.ServiceDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
        private readonly IService<Service> _service;
        private readonly IMapper _mapper;

        public ServiceController(IService<Service> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Services()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Service>(serviceDto);
                await _service.AddAsync(model);

                return Ok();
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            await _service.SafeDeletedAsync(model);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Service>(updateServiceDto);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Service(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
    }
}
