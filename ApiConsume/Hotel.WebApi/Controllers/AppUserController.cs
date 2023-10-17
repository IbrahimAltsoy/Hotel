using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.DataAccessLayer;
using Hotel.EntitiyLayer.Concreate;
using Hotel.WebApi.Models;
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
        private readonly AppDbContext _appContext;
        



        public AppUserController(IAppUserService appUserService, IMapper mapper, UserManager<AppUser> userManager, AppDbContext appContext)
        {

            _appUserService = appUserService;
            _mapper = mapper;
            _userManager = userManager;
            _appContext = appContext;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetUserWithLocation()
        {
            AppDbContext appDbContext = new AppDbContext();

            //var model =await _appUserService.UserListWithWorkLocation();
            var model =await appDbContext.Users.Include(u => u.WorkLocation).Select(x => new AppUserWithWorkLocaionViewModel
            {
                Name = x.Name,
                Surname = x.Surname,
               City = x.City,
               ImageUrl = x.ImageUrl,
               WorkLocationName = x.WorkLocation.Name

            }).ToListAsync();
            if (model!=null)
            {
                return Ok(model);
            }

            return Ok();
        }
        //[HttpGet("AppUserList")]
        //public async Task<IActionResult> GetUser()
        //{
        //    var model =await _
        //    return Ok(model);
        //}
    }
}
