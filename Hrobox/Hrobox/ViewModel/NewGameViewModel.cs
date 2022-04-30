﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    public class NewGameViewModel : ViewModelBase
    {
        public GameModel GameModel { get; set; }
        public List<TagModel> TagModels { get; set; }
        private ICommand createGame; 
        public ICommand CreateGame { get; }
        private readonly INavigationService navigationService;

        public NewGameViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.createGame = new DelegateCommand(CreateGameCommand);
            this.GameModel = new GameModel();
        }

        private void CreateGameCommand()
        {
            throw new NotImplementedException();
        }
    }
}
