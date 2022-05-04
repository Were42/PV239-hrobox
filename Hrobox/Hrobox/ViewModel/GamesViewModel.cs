using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Repository;
using Hrobox.Services;
using Hrobox.Services.Interfaces;

namespace Hrobox.ViewModel
{
    public class GamesViewModel : ViewModelBase
    {
        public ObservableCollection<GameModel> Games { get; set; } = new();
        public ObservableCollection<TagModel> Tags { get; set; } = new();
        public bool IsQuarter { get; set; }
        
        public bool IsHalf { get; set; }
        public bool IsHour { get; set; }
        public bool IsHourPlus { get; set; }
        public bool IsAll { get; set; } = true;
        public bool IsKids { get; set; }
        public bool IsSchool { get; set; }
        public bool IsTeen { get; set; }
        public bool IsAdult { get; set; }

        public string KeyWord { get; set; } = "";

        public FilterModel Filter { get; set; }

        private ICommand find;
        public ICommand Find => find;
        private ICommand createGame;
        public ICommand CreateGame => createGame;
        private ICommand createTag;
        public ICommand CreateTag => createTag;
        private ICommand login;
        public ICommand Login => login;
        private ICommand openPicker;
        public ICommand OpenPicker => openPicker;
        private readonly IGameRepository GameRepository;
        private readonly INavigationService navigationService;
        
        public GamesViewModel(INavigationService navigationService, IGameRepository gameRestRepository)
        {
            this.navigationService = navigationService;
            this.GameRepository = gameRestRepository;
            //todo: delete this test data. Ph before calling to server is implemented
            Tags.Add(new TagModel()
            {
                Name = "Ball",
                IsSelected = false
            });
            Tags.Add(new TagModel()
            {
                Name = "Thinking",
                IsSelected = false
            });
            Tags.Add(new TagModel()
            {
                Name = "Running",
                IsSelected = false
            });
            Games.Add(new GameModel()
            {
                FirstTag = "Thinking",
                Name = "Puzzles",
                MinMaxNumPlayers = "4-5"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "Ball",
                Name = "Football",
                MinMaxNumPlayers = "11-18"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "Ball",
                Name = "Soccer",
                MinMaxNumPlayers = "11-18"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "Hand",
                Name = "Juggling",
                MinMaxNumPlayers = "1-6"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            Games.Add(new GameModel()
            {
                FirstTag = "TagPH",
                Name = "GameNamePH",
                MinMaxNumPlayers = "4-8"
            });
            find = new AsyncCommand(FindIt, null,  null, false);
            createGame = new AsyncCommand(CreateGameFunction, null, null, false);
            createTag = new AsyncCommand(CreateTagFunction, null, null, false);
            login = new AsyncCommand(LoginFunction, null, null, false);
            openPicker = new AsyncCommand(OpenPickerFunction, null, null, false);
        }

        public async Task FindIt()
        {
            this.FillingModel();
            this.Games = new ObservableCollection<GameModel>(await GameRepository.GetAll(this.Filter));

        }

        public void FillingModel()
        {
            this.Filter = new FilterModel();
            if (this.IsQuarter == true)
            {
                this.Filter.Duration.Add("<15");
            }
            if (this.IsHalf == true)
            {
                this.Filter.Duration.Add("15-30");
            }
            if (this.IsHour == true)
            {
                this.Filter.Duration.Add("30-60");
            }
            if (this.IsHourPlus == true)
            {
                this.Filter.Duration.Add("60+");
            }
            if (this.IsAll == true)
            {
                this.Filter.Duration = new List<string> { "<15", "15-30", "30-60", "60+" };
            }
            if (this.IsKids == true)
            {
                this.Filter.AgeGroup.Values.Add("K");
            }
            if (this.IsSchool == true)
            {
                this.Filter.AgeGroup.Values.Add("S");
            }
            if (this.IsTeen == true)
            {
                this.Filter.AgeGroup.Values.Add("T");
            }
            if (this.IsAdult == true)
            {
                this.Filter.AgeGroup.Values.Add("A");
            }

            this.Filter.Name = KeyWord;
        }
        public async Task CreateGameFunction()
        {
            await navigationService.PushAsync<NewGameViewModel>();
        }
        public async Task CreateTagFunction()
        {
            await navigationService.PushAsync<NewTagViewModel>();
        }
        public async Task LoginFunction()
        {
            await navigationService.PushAsync<LoginViewModel>();
        }
        public async Task OpenPickerFunction()
        {
            await navigationService.PushAsync<MultiPickerViewModel, ObservableCollection<TagModel>>(Tags);
        }
        public override async Task OnAppearingAsync()
        {
        }
    }
}
