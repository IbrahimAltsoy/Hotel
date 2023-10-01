using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.AboutDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IService<About> _service;
        private readonly IMapper _mapper;

        public AboutController(IService<About> service, IMapper mapper)
        {
            
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> AboutAllGet()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(AddAboutDto addAbout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<About>(addAbout);
                await _service.AddAsync(model);

                return Ok();
            }

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteAbout(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAbout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<About>(updateAbout);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> About(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
    }
}
