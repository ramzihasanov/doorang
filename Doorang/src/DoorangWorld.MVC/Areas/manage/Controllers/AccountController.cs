using DoorangWorld.Business.CustomException.AccountException;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Business.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoorangWorld.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                service.Login(model);

            }
            catch (InvalidLoginException ex)
            {
                if(!ModelState.IsValid) { return View(); }
                ModelState.AddModelError(ex.propertyname, ex.Message);
                return View(model);

            }
            catch (Exception)
            {
                return View("error");
            }
            return RedirectToAction("Index","dashboard");
        }
    }
}
