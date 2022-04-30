using System;
using System.Collections.Generic;
using System.Text;
using Hrobox.Model;

namespace Hrobox.ViewModel
{
    public class GameDetailViewModels : ViewModelBase
    {
        public GameModel GameModel { get; set; }

        public GameDetailViewModels()
        {
            GameModel = new GameModel();
            this.GameModel.Name = "Hra na slepou bábu";
            this.GameModel.Duration = Duration.DurationEnum.Fifteenminutes;
            this.GameModel.MaxNumPlayers = 10;
            this.GameModel.MinNumPlayers = 2;
            this.GameModel.Rules = "Bla la la la la la ";
            this.GameModel.Version = "1.1";
        }
    }
}
