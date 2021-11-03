using Kurzusok.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.Controllers
{
   [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {            
            var roles = roleManager.Roles.ToList();
            var model = new List<RolesViewModel>();           

            foreach (var role in roles)
            {
                List<String> Users = new List<string>();

                var RoleModel = new RolesViewModel
                {
                    roleId = role.Id,
                    roleName = role.Name
                };
                foreach (var user in userManager.Users.ToList())
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        Users.Add((string)user.UserName);

                    }
                }
                RoleModel.Users = Users;
                model.Add(RoleModel);
            }
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUserRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            ViewBag.roleName = role.Name;
            var model = new List<RoleEditViewModel>();
            foreach (var user in userManager.Users.ToList())
            {
                var roleEditViewModel = new RoleEditViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName

                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    roleEditViewModel.Selected = true;
                }
                else
                {
                    roleEditViewModel.Selected = false;

                }
                model.Add(roleEditViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRole(List<RoleEditViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult Iresult = null;
                if (model[i].Selected == true && (await userManager.IsInRoleAsync(user, role.Name) == false))
                {
                     Iresult = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(model[i].Selected == false && (await userManager.IsInRoleAsync(user, role.Name) == true))
                {
                    Iresult = await userManager.RemoveFromRoleAsync(user, role.Name);
                } 

            }
            return RedirectToAction("Index");
        }


    }
}
