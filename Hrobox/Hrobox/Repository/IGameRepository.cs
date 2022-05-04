using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface IGameRepository
    {
        Task<ObservableCollection<OutputGameModel>> GetAll(FilterModel filterModel);
        Task<GameDetailModel> GetById(OutputGameModel id);
        Task CreateGame(NewGameModel game, string jwt);
        Task UpdateGame(GameModel game);
        Task deleteGame(string id);

    }
}