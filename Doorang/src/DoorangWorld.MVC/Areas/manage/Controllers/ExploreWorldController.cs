using DoorangWorld.Business.CustomException.ExploreException;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoorangWorld.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles = "Superadmin")]
    public class ExploreWorldController : Controller
    {
        private readonly IExploreWorldService service;

        public ExploreWorldController(IExploreWorldService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await service.GettAllAsync());
        }
        public  IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(ExploreWorld world)
        {
            try
            {
                await service.CreateAsync(world);
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.proprtyname, ex.Message);
                return View();

            }
            catch (InvalidImageTypeException ex)
            {
                ModelState.AddModelError(ex.proprtyname, ex.Message);
                return View();
            }
            catch (ExploreNullException)
            {
                return View("Error");
            }
            catch (Exception)
            {

                return View("Error");
            }
           return RedirectToAction("index");
        }
        public async Task< IActionResult> Update(int id)
        {
            var world=await service.GetAsync(x=>x.Id == id);
            return View(world);
        }
        [HttpPost]
        public async Task< IActionResult> Update(ExploreWorld world)
        {
            try
            {
                await service.UpdateAsync(world);
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.proprtyname, ex.Message);
                return View();

            }
            catch (InvalidImageTypeException ex)
            {
                ModelState.AddModelError(ex.proprtyname, ex.Message);
                return View();
            }
            catch (ExploreNullException)
            {
                return View("Error");
            }
            catch (Exception)
            {

                return View("Error");
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id) {
            var world = await service.GetAsync(x => x.Id == id);
            return View(world);
                }
        [HttpPost]
        public async Task< IActionResult> Delete(ExploreWorld exp)
        {    

            try
            {
                await service.HardDeleteAsync(exp.Id);
            }
            catch (Exception)
            {
                return View("error");

            }
            return View();
        }
        
    }
}
