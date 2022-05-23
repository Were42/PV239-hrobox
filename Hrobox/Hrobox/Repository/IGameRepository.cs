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
        Task<string> CreateGame(NewGameModel game);

    }
}