using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Repository;
using Hrobox.Services.Interfaces;

namespace Hrobox.ViewModel
{
    public class NewGameViewModel : ViewModelBase
    {
        public NewGameModel GameModel { get; set; }
        public List<TagModel> TagModels { get; set; }
        private ICommand createGame; 
        public ICommand CreateGame { get; }
        private readonly INavigationService navigationService;
        public IGameRepository GameRepository { get; set; }

        public NewGameViewModel(INavigationService navigationService, GameRestRepository gameRepository)
        {
            this.navigationService = navigationService;
            this.createGame = new AsyncCommand(CreateGameCommand, null, null, false);
            this.GameRepository = gameRepository;
            this.GameModel = new NewGameModel();
        }

        private async Task CreateGameCommand()
        {
            try
            {
                await GameRepository.CreateGame(GameModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
