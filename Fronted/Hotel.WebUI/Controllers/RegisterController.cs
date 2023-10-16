using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Create_AppUser_Dto _user)
        {
            if(!ModelState.IsValid)
                return View();
            var appUser = new AppUser()
            {
                Name = _user.Name,
                Surname = _user.Surname,
                Email = _user.Mail,
                UserName = _user.Username,
                City = _user.City,
                WorkLocationId = _user.WorkLocationId,



            };
            var result = await _userManager.CreateAsync(appUser, _user.Password);
            if(result.Succeeded) 
                return RedirectToAction(nameof(Index), "Login");
            else
                return View();
           
        }
    }
}
