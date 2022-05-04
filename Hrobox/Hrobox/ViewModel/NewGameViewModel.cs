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
using Hrobox.ViewModel.Interfaces;

namespace Hrobox.ViewModel
{
    public class NewGameViewModel : ViewModelBase, IViewModel<SignInUserModel>
    {
        public GameModel GameModel { get; set; }
        public SignInUserModel SignInUserModel { get; set; }

        public List<TagModel> TagModels { get; set; }
        private ICommand createGame;
        public ICommand CreateGame => createGame;
        private readonly INavigationService navigationService;
        private readonly IGameRepository gameRepository;

        public NewGameViewModel(INavigationService navigationService, IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
            this.navigationService = navigationService;
            this.createGame = new AsyncCommand(CreateGameCommand, null, null, false);
            this.GameModel = new GameModel();
        }

        private async Task CreateGameCommand()
        {
           await gameRepository.CreateGame(GameModel);
        }

        public void SetViewModelParameter(SignInUserModel? parameter)
        {
            SignInUserModel = parameter;
        }
    }
}
