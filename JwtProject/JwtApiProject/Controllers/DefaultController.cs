using JwtApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok(new CreateToken().TokenCreate());
        }
        [HttpGet("[action]")]
        public IActionResult CreateAdminToken()
        {
            return Ok(new CreateToken().CreateAdminToken());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Merhaba");
        }
        [Authorize(Roles ="Adin, Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Token oluşturuldu");
        }
    }
}
