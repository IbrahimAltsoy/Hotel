using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.WorkLocationDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IService<WorkLocation> _service;
        private readonly IMapper _mapper;

        public WorkLocationController(IService<WorkLocation> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> WorkLocations()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(AddWorkLocationDto addWorkLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<WorkLocation>(addWorkLocationDto);
                await _service.AddAsync(model);

                return Ok();
            }

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteWorkLocation(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto updateWorkLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<WorkLocation>(updateWorkLocationDto);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> WorkLocation(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
    }
}
