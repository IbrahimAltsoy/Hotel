using Hotel.BusinessLayer.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly IStuffService _service;

		public StaffController(IStuffService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Stuffs()
		{
			var model = await _service.GetAllAsync();
			return Ok(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddStuffs(Stuff stuff)
		{
			await _service.AddStuffAsync(stuff);
			return Ok();
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteStuffs(Guid id)
		{
			var model = await _service.GetByIdAsync(id);			 
			return Ok(await _service.SafeDeletedStuff(model));
		}
		[HttpPut]
		public async Task<IActionResult> UpdateStuffs(Stuff stuff)
		{
			await _service.UpdateStaffAsync(stuff);
			return Ok();
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Stuff(Guid id)
		{			
			return Ok(await _service.GetByIdAsync(id));
		}
	}
}
