using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        



        public AppUserController(IAppUserService appUserService, IMapper mapper, UserManager<AppUser> userManager)
        {

            _appUserService = appUserService;
            _mapper = mapper;
            _userManager = userManager;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetUserWithLocation()
        {
            
            var model =await _appUserService.UserListWithWorkLocation();
            int a = 0;
            return Ok(model);
        }
        //[HttpGet("AppUserList")]
        //public async Task<IActionResult> GetUser()
        //{
        //    var model =await _
        //    return Ok(model);
        //}
    }
}
