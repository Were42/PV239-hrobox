using System.Collections.Generic;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface IGameRepository
    {
        Task<List<GameModel>> GetAll();
        Task CreateGame(GameModel game, bool isNewItem);
        Task UpdateGame(GameModel game, bool isNewItem);
        Task deleteGame(string id);

    }
}