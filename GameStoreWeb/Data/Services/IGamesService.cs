using GameStoreWeb.Data.Base;
using GameStoreWeb.Data.ViewModels;
using GameStoreWeb.Models;

namespace GameStoreWeb.Data.Services
{
    public interface IGamesService : IEntityBaseRepository<Game>
    {
        Task<Game> GetGameByIdAsync(int id);
        Task<NewGameDropdownsVM> GetNewGameDropdownsValues();
        Task AddNewGameAsync(NewGameVM data);
        Task UpdateGameAsync(NewGameVM data);
    }
}
