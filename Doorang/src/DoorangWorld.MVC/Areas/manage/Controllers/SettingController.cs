using DoorangWorld.Business.CustomException.SettingException;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoorangWorld.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Superadmin")]
    public class SettingController : Controller
    {
        private readonly IsettingService service;

        public SettingController(IsettingService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await service.GettAllsetting());
        }

        public IActionResult Update()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Setting setting)
        {
            if(!ModelState.IsValid) { return View(); }
            try
            {
                await service.Update(setting);
            }
            catch (NullSettingException ex)
            {
                return View("error");

            }
            catch (Exception)
            {

                return View("error");
            }

            return RedirectToAction("index");
            
        }
    }
}
