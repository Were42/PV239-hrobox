using System;
using System.Collections.Generic;
using System.Text;
using Hrobox.Model;
using Hrobox.Services.Interfaces;

namespace Hrobox.ViewModel
{
    public class GameDetailViewModels : ViewModelBase
    {
        public GameModel GameModel { get; set; }

        private readonly INavigationService navigationService;

        public GameDetailViewModels(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GameModel = new GameModel();
            this.GameModel.Name = "Hra na slepou bábu";
            this.GameModel.Duration = "<15";
            this.GameModel.MaxNumPlayers = 10;
            this.GameModel.MinNumPlayers = 2;
            this.GameModel.Rules = "Bla la la la la la ";
            this.GameModel.Version = "1.1";
        }
    }
}
