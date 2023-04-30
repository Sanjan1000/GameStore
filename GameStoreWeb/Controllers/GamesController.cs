using GameStoreWeb.Data;
using GameStoreWeb.Data.Services;
using GameStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWeb.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _service;
        public GamesController(IGamesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allGames = await _service.GetAllAsync();
            return View(allGames);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allGames = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allGames.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }
            return View("Index", allGames);
        }

            public async Task<IActionResult> Details(int id)
        {
            var gameDetails = await _service.GetGameByIdAsync(id);
            return View(gameDetails);
        }
        //Get:Games
        public async Task<IActionResult> Create()
        {
            var gameDropdownsData = await _service.GetNewGameDropdownsValues();
            ViewBag.Producers = new SelectList(gameDropdownsData.Producers, "Id", "FullName");
            ViewBag.Developers = new SelectList(gameDropdownsData.Developers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewGameVM game)
        {
            if (!ModelState.IsValid)
            {
                var gameDropdownsData = await _service.GetNewGameDropdownsValues();

                ViewBag.Producers = new SelectList(gameDropdownsData.Producers, "Id", "FullName");
                ViewBag.Developers = new SelectList(gameDropdownsData.Developers, "Id", "FullName");

                return View(game);
            }

            await _service.AddNewGameAsync(game);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var gameDetails = await _service.GetGameByIdAsync(id);
            if (gameDetails == null) return View("NotFound");

            var response = new NewGameVM()
            {
                Id = gameDetails.Id,
                Name = gameDetails.Name,
                Description = gameDetails.Description,
                Price = gameDetails.Price,
                ReleaseDate = gameDetails.ReleaseDate,
                ImageURL = gameDetails.ImageURL,
                GameCategory = gameDetails.GameCategory,

                ProducerId = gameDetails.ProducerId,
                DeveloperIds = gameDetails.Developer_Games.Select(n => n.DeveloperId).ToList(),
            };

            var gameDropdownsData = await _service.GetNewGameDropdownsValues();

            ViewBag.Producers = new SelectList(gameDropdownsData.Producers, "Id", "FullName");
            ViewBag.Developers = new SelectList(gameDropdownsData.Developers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewGameVM game)
        {
            if (id != game.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var gameDropdownsData = await _service.GetNewGameDropdownsValues();


                ViewBag.Producers = new SelectList(gameDropdownsData.Producers, "Id", "FullName");
                ViewBag.Developers = new SelectList(gameDropdownsData.Developers, "Id", "FullName");

                return View(game);
            }

            await _service.UpdateGameAsync(game);
            return RedirectToAction(nameof(Index));
        }
    }
}
