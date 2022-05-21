using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Repository;
using Hrobox.Services.Interfaces;

namespace Hrobox.ViewModel
{
    public class GamesViewModel : ViewModelBase
    {
        public ObservableCollection<OutputGameModel> Games { get; set; } = new();
        public ObservableCollection<TagModel> Tags { get; set; } = new();
        private TagsModel _tagsWithAllInfo;

        public SignInUserModel? User { get; set; }

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
        public bool IsLogged { get; set; } = false;
        public bool CanLog { get; set; } = true;
        public bool Loading { get; set; } = false;
        public FilterModel Filter { get; set; }

        public ICommand FindCommand { get; set; }
        public ICommand CreateGameCommand { get; set; }
        public ICommand CreateTagCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand OpenPickerCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        private readonly IGameRepository _gameRepository;
        private readonly INavigationService _navigationService;
        private readonly ITagRepository _tagRepository;
        
        public GamesViewModel(INavigationService navigationService, IGameRepository gameRestRepository, ITagRepository tagRepository)
        {
            this._navigationService = navigationService;
            this._gameRepository = gameRestRepository;
            this._tagRepository = tagRepository;
            
            FindCommand = new AsyncCommand(FindIt, null,  null, false);
            User = new SignInUserModel();
            CreateGameCommand = new AsyncCommand(CreateGameFunction, null, null, false);
            CreateTagCommand = new AsyncCommand(CreateTagFunction, null, null, false);
            LoginCommand = new AsyncCommand(LoginFunction, null, null, false);
            OpenPickerCommand = new AsyncCommand(OpenPickerFunction, null, null, false);
            OpenDetailCommand = new AsyncCommand<int>(OpenDetailFuction, null, null, false);
        }

        public async Task FindIt()
        {
            this.FillingModel();
            this.Loading = true;
            this.Games = await _gameRepository.GetAll(this.Filter);
            this.Loading = false;
        }

        public void FillingModel()
        {
            this.Filter = new FilterModel()
            {
                Duration = new List<string>(),
                AgeGroup = new AgeGroup()
                {
                    Values = new List<string>()

                },
                Tags = new FilterTagModel(){ Values = new List<int>()}
            };
            if (this.IsQuarter)
            {
                this.Filter.Duration.Add("<15");
            }else if (this.IsHalf)
            {
                this.Filter.Duration.Add("15-30");
            } else if (this.IsHour)
            {
                this.Filter.Duration.Add("30-60");
            } else if (this.IsHourPlus)
            {
                this.Filter.Duration.Add("60+");
            } else if (this.IsAll)
            {
                this.Filter.Duration = new List<string> { "<15", "15-30", "30-60", "60+" };
            }
            if (this.IsKids)
            {
                this.Filter.AgeGroup.Values.Add("K");
            }
            if (this.IsSchool)
            {
                this.Filter.AgeGroup.Values.Add("S");
            }
            if (this.IsTeen)
            {
                this.Filter.AgeGroup.Values.Add("T");
            }
            if (this.IsAdult)
            {
                this.Filter.AgeGroup.Values.Add("A");
            }
            this.Filter.Name = KeyWord;
            foreach (var tagModel in Tags)
            {
                if (tagModel.IsSelected)
                {
                    //todo find id
                    var result = _tagsWithAllInfo.tags.Find(x => x.NameEn.Equals(tagModel.Name));
                    if (result != null)
                    {
                        this.Filter.Tags.Values.Add((int)result.Id);
                    }
                }
            }
        }
        public async Task CreateGameFunction()
        {
            await _navigationService.PushAsync<NewGameViewModel, SignInUserModel>(User);
        }
        public async Task CreateTagFunction()
        {
            await _navigationService.PushAsync<NewTagViewModel, SignInUserModel>(User);
        }
        public async Task LoginFunction()
        {
            await _navigationService.PushAsync<LoginViewModel, SignInUserModel>(User);
        }
        public async Task OpenPickerFunction()
        {
            this._tagsWithAllInfo = await _tagRepository.GetAllTags();
            foreach (var tag in _tagsWithAllInfo.tags)
            {
                if (this.Tags.Any(x => x.Name.Equals(tag.NameEn)))
                {
                    continue;
                }
                this.Tags.Add(new TagModel() { Name = tag.NameEn });
            }
            await _navigationService.PushAsync<MultiPickerViewModel, ObservableCollection<TagModel>>(Tags);
        }
        public async Task OpenDetailFuction(int Id)
        {
            var game = Games.First();
            foreach (var outputGameModel in Games)
            {
                if (outputGameModel.Id == Id)
                {
                    game = outputGameModel;
                    break;
                }
            }
            var result = await _gameRepository.GetById(game);
            await _navigationService.PushAsync<GameDetailViewModel, GameDetailModel>(result);
        }
        public override async Task OnAppearingAsync()
        {
            if (!(Games.Count > 0))
            {
                this.Filter = new FilterModel();
                this.Filter.AgeGroup = new AgeGroup() { Values = new List<string>() { "K", "T", "A", "S" } };
                this.Filter.Duration = new List<string> { "<15", "15-30", "30-60", "60+" };
                this.Loading = true;
                this.Games = await _gameRepository.GetAll(this.Filter);
                this.Loading = false;
            }
            if (User.Role != null)
            {
                IsLogged = true;
                CanLog = false;
            }
        }
    }
}
