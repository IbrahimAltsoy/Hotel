﻿using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {

            return View(_userManager.Users.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Assign(Guid id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["userId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.Id = role.Id;
                roleAssignViewModel.Name = role.Name;
                roleAssignViewModel.RoleExist = userRoles.Contains(role.Name);
                roleAssignViewModels.Add(roleAssignViewModel);
            }
            return View(roleAssignViewModels);

        }
        [HttpPost]
        public async Task<IActionResult> Assign(List<RoleAssignViewModel> roleAssignViewModel)
        {
            var userId = Guid.Parse(TempData["userId"].ToString());
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userId);
            foreach(var role in roleAssignViewModel)
            {
                if (role.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
