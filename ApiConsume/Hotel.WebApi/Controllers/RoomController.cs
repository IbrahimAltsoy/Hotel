using Microsoft.AspNetCore.Mvc;
namespace Hotel.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		[HttpGet]
		public IActionResult Rooms()
		{
			return Ok();
		}
		[HttpPost]
		public IActionResult AddRoom()
		{
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteRoom()
		{
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateRoom()
		{
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult Room()
		{
			return Ok();
		}
	}
}
