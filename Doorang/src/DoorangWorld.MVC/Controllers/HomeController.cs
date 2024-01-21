
using DoorangWorld.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoorangWorld.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExploreWorldService service;

        public HomeController(IExploreWorldService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await service.GettAllAsync());
        }


        
    }
}