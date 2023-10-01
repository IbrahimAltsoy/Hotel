using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login_User_Dto _user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(_user.UserName, _user.Password, false, true);
                if(result.Succeeded)
                    return RedirectToAction("Index", "Room");
                else return View();




            }
            return View();

        }
    }
}
