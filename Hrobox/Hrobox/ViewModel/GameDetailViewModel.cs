using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using Hrobox.ViewModel.Interfaces;

namespace Hrobox.ViewModel
{
    public class GameDetailViewModel : ViewModelBase, IViewModel<GameDetailModel>
    {
        public GameDetailModel GameModel { get; set; }
        public string AgeGroups { get; set; }
        public string Tags { get; set; }

        private readonly INavigationService _navigationService;

        public GameDetailViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            GameModel = new GameDetailModel();
            this.GameModel.NrOfPlayers = new NrOfPlayers();
        }

        public void SetViewModelParameter(GameDetailModel? parameter)
        {
            GameModel = parameter;
            AgeGroups = string.Join(", ", GameModel.AgeGroups);
            Tags = string.Join(", ", GameModel.Tags);

        }
    }
}
