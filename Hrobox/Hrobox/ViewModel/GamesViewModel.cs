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
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    public class GamesViewModel : ViewModelBase
    {
        public ObservableCollection<GameModel> Games { get; set; } = new ObservableCollection<GameModel>();
        public ObservableCollection<TagModel> Tags { get; set; } = new ObservableCollection<TagModel>();

        public bool IsQuarter
        {
            get => IsQuarter;
            set
            {
                if (value)
                {
                    this.Filter.Duration.Add("<15");
                }

                IsQuarter = value;
            }
        }

        public bool IsHalf
        {
            get => IsHalf;
            set
            {
                if (value)
                {
                    this.Filter.Duration.Add("15-30");
                }

                IsHalf = value;
            }
        }

        public bool IsHour
        {
            get => IsHour;
            set
            {
                if (value)
                {
                    this.Filter.Duration.Add("30-60");
                }

                IsHour = value;
            }
        }

        public bool IsHourPlus
        {
            get => IsHourPlus;
            set
            {
                if (value)
                {
                    this.Filter.Duration.Add("60+");
                }

                IsHourPlus = value;
            }
        }

        public bool IsAll
        {
            get => IsAll;
            set
            {
                if (value)
                {
                    this.Filter.Duration = new List<string> {"<15", "15-30", "30-60", "60+"};
                }

                IsAll = value;
            }
        }
        public bool IsKids {
            get => IsKids;
            set
            {
                if (value)
                {
                    this.Filter.AgeGroup.Values.Add("K");
                }

                IsKids = value;
            }
        }
        public bool IsSchool {
            get => IsSchool;
            set
            {
                if (value)
                {
                    this.Filter.AgeGroup.Values.Add("A");
                }

                IsSchool = value;
            }
        }
        public bool IsTeen {
            get => IsTeen;
            set
            {
                if (value)
                {
                    this.Filter.AgeGroup.Values.Add("T");
                }

                IsTeen = value;
            }
        }
        public bool IsAdult {
            get => IsAdult;
            set
            {
                if (value)
                {
                    this.Filter.AgeGroup.Values.Add("A");
                }
                IsAdult = value;
            }
        }

        public string KeyWord
        {
            get => KeyWord;
            set
            {
                this.Filter.Name = value;
            }
        }
        public FilterModel Filter { get; set; }

        private ICommand find;
        public ICommand Find => find;
        private ICommand createGame;
        public ICommand CreateGame => createGame;
        private ICommand createTag;
        public ICommand CreateTag => createTag;
        private ICommand login;
        public ICommand Login => login;

        private readonly INavigationService navigationService;
        private readonly IGameRepository gameRepository;
        public GamesViewModel(INavigationService navigationService, IGameRepository gameRestRepository)
        {
            this.navigationService = navigationService;
            this.gameRepository = gameRestRepository;
            this.IsAll = true;

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
            find = new AsyncCommand(FindIt, null, null, false);
            createGame = new AsyncCommand(CreateGameFunction, null, null, false);
            createTag = new AsyncCommand(CreateTagFunction, null, null, false);
            login = new AsyncCommand(LoginFunction, null, null, false);
        }

        public async Task FindIt()
        {
           Games = new ObservableCollection<GameModel>(await gameRepository.GetAll(Filter));
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
        public override async Task OnAppearingAsync()
        {
        }
    }
}
