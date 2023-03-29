using Hotel.BusinessLayer.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		
		private readonly IService<Stuff> _service;

		public StaffController(IService<Stuff> service)
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
			//if (model==null)
			//{
			//	return BadRequest();
			//}
			//else
			//{
			//	await _service.AllDeletedStuff(model.Id);
			//	return StatusCode(StatusCodes.Status200OK);
			//}

		}
		
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateStuffs(Stuff stuff)
		{
			await _service.UpdateAsync(stuff);
			return NoContent();
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Stuff(Guid id)
		{			
			return Ok(await _service.GetByIdAsync(id));
		}
	}
}
