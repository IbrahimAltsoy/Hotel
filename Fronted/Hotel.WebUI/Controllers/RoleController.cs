using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel roleViewModel)
        {
            AppRole appRole = new AppRole(){
                Name = roleViewModel.Name
            };
            var result = await _roleManager.CreateAsync(appRole);
            if(result.Succeeded) RedirectToAction("Index");
            else return View();
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
           await _roleManager.DeleteAsync(model);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var model = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel roleViewModel = new UpdateRoleViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
            return View(roleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleViewModel roleViewModel)
        {
            var model = _roleManager.Roles.FirstOrDefault(x=>x.Id == roleViewModel.Id);
            model.Name = roleViewModel.Name;
            await _roleManager.UpdateAsync(model);
            return RedirectToAction("Index");

        }

    }
}
