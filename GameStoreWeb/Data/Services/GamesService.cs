using GameStoreWeb.Data.Base;
using GameStoreWeb.Data.ViewModels;
using GameStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreWeb.Data.Services
{
    public class GamesService : EntityBaseRepository<Game>, IGamesService
    {
        private readonly AppDbContext _context;
        public GamesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewGameAsync(NewGameVM data)
        {
            var newGame = new Game()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ReleaseDate = data.ReleaseDate,
                GameCategory = data.GameCategory,
                ProducerId = data.ProducerId
            };
            await _context.Games.AddAsync(newGame);
            await _context.SaveChangesAsync();

            //Add Game Developers
            foreach (var DeveloperId in data.DeveloperIds)
            {
                var newDeveloperGame = new Developer_Games()
                {
                    GamesId = newGame.Id,
                    DeveloperId = DeveloperId
                };
                await _context.Developer_Games.AddAsync(newDeveloperGame);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var GameDetails = await _context.Games
                .Include(p => p.Producer)
                .Include(dg => dg.Developer_Games).ThenInclude(d => d.Developer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return GameDetails;
        }

        public async Task<NewGameDropdownsVM> GetNewGameDropdownsValues()
        {
            var response = new NewGameDropdownsVM()
            {
                Developers = await _context.Developers.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateGameAsync(NewGameVM data)
        { 
            var dbGame = await _context.Games.FirstOrDefaultAsync(n=>n.Id == data.Id);
            if (dbGame != null)
            {
               
                {
                    dbGame.Name = data.Name;
                    dbGame.Description = data.Description;
                    dbGame.Price = data.Price;
                    dbGame.ImageURL = data.ImageURL;
                    dbGame.ReleaseDate = data.ReleaseDate;
                    dbGame.GameCategory = data.GameCategory;
                    dbGame.ProducerId = data.ProducerId;
                    await _context.SaveChangesAsync();
                };
                
            }
             var existingDevelopersDb= _context.Developer_Games.Where(n=>n.GamesId == data.Id).ToList();
             _context.Developer_Games.RemoveRange(existingDevelopersDb);
            await _context.SaveChangesAsync();
            //Add Game Developers
            foreach (var DeveloperId in data.DeveloperIds)
            {
                var newDeveloperGame = new Developer_Games()
                {
                    GamesId = data.Id,
                    DeveloperId = DeveloperId
                };
                await _context.Developer_Games.AddAsync(newDeveloperGame);
            }
            await _context.SaveChangesAsync();
        }


    }
}
    
