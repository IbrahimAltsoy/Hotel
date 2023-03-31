using Hotel.BusinessLayer.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
        private readonly IService<Testimonial> _service;

        public TestimonialController(IService<Testimonial> service)
        {

            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Testimonials()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(Testimonial testimonial)
        {
            await _service.AddAsync(testimonial);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(await _service.SafeDeletedAsync(model));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonial(Testimonial testimonial)
        {
            await _service.UpdateAsync(testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Testimonial(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
