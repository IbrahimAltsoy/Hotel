using Hotel.BusinessLayer.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StuffController : ControllerBase
	{
		
		private readonly IService<Stuff> _service;

		public StuffController(IService<Stuff> service)
		{
			
			_service = service;
		}        
        [HttpGet]
		public async Task<IActionResult> Stuffs()
		{
			var model = await _service.GetAllIsActiveTrueAsync();
			return Ok(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddStuffs(Stuff stuff)
		{
			await _service.AddAsync(stuff);
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStuffs(Guid id)
		{
			var model = await _service.GetByIdAsync(id);
			return Ok(await _service.SafeDeletedAsync(model));
			
		}      
        [HttpPut("{id}")]
		public async Task<IActionResult> UpdateStuffs(Stuff stuff)
		{
			await _service.UpdateAsync(stuff);
			return Ok();
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Stuff(Guid id)
		{			
			return Ok(await _service.GetByIdAsync(id));
		}
	}
}
