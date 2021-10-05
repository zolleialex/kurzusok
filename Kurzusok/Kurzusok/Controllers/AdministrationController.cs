using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurzusok.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;

        }
        public IActionResult Index()
        {
            //IdentityRole identityRole = new IdentityRole
            //{
            //    Name = "Commenter"
            //};
            //IdentityResult result = await roleManager.CreateAsync(identityRole);
            var roles = roleManager.Roles;
            return View(roles);
        }
    }
}
