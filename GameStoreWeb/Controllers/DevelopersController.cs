using GameStoreWeb.Data.Services;
using GameStoreWeb.Data;
using GameStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreWeb.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly IDeveloperService _service;


        public DevelopersController(IDeveloperService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return View(developer);
            }
           await _service.AddAsync(developer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var developerDetails = await _service.GetByIdAsync(id);

            if (developerDetails == null) return View("NotFound");
            return View(developerDetails);



        }
        public async Task<IActionResult> Edit(int id)
        {
            var developerDetails = await _service.GetByIdAsync(id);
            if (developerDetails == null) return View("NotFound");
            return View(developerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return View(developer);
            }
            await _service.UpdateAsync(id,developer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var developerDetails = await _service.GetByIdAsync(id);
            if (developerDetails == null) return View("NotFound");
            return View(developerDetails);

        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developerDetails = await _service.GetByIdAsync(id);
            if (developerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
