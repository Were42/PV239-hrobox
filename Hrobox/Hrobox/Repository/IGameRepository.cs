using System.Collections.Generic;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface IGameRepository
    {
        Task<List<GameModel>> GetAll(FilterModel filterModel);
        Task<GameModel> GetById(int id);
        Task CreateGame(GameModel game);
        Task UpdateGame(GameModel game);
        Task deleteGame(string id);

    }
}