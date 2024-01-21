using DoorangWorld.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoorangWorld.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles = "Superadmin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DashboardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> createroll()
        //{
        //    IdentityRole role=new IdentityRole("Superadmin");
        //  await  roleManager.CreateAsync(role);
        //    return Ok();
        //}
        //public async Task<IActionResult> Createadmin()
        //{
        //    AppUser appUser = new AppUser()
        //    {
        //        Fullname = "Remzi heseov",
        //        UserName = "Superadmin",
        //    };
        //  await  userManager.CreateAsync (appUser,"Admin123@");
        //    await userManager.AddToRoleAsync(appUser, "Superadmin");

        //    return Ok();
        //}
    }
}
