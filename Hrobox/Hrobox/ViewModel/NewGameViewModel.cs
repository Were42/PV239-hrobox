using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        public NewGameModel GameModel { get; set; }
        public SignInUserModel SignInUserModel { get; set; }
        public ObservableCollection<TagModel> Tags { get; set; } = new();
        public bool IsKids { get; set; }
        public bool IsSchool { get; set; }
        public bool IsTeen { get; set; }
        public bool IsAdult { get; set; }
        public bool IsQuarter { get; set; }
        public bool IsHalf { get; set; }
        public bool IsHour { get; set; }
        public bool IsHourPlus { get; set; }
        public ICommand CreateGame { get; set; }
        public ICommand OpenPicker { get; set; }
        private readonly INavigationService navigationService;
        private readonly IGameRepository gameRepository;
        private readonly ITagRepository tagRepository;
        private readonly IMessageService messageService;
        private TagsModel _tagsModel;

        public NewGameViewModel(INavigationService navigationService,
            IGameRepository gameRepository,
            ITagRepository tagRepository,
            IMessageService messageService)
        {
            this.gameRepository = gameRepository;
            this.tagRepository = tagRepository;
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.CreateGame = new AsyncCommand(CreateGameCommand, null, null, false);
            this.OpenPicker = new AsyncCommand(OpenPickerCommand, null, null, false);
            this.GameModel = new NewGameModel(){NrOfPlayers = new NrOfPlayers()};
        }

        private async Task CreateGameCommand()
        {
            FillingModel();
            var msg = await gameRepository.CreateGame(GameModel, SignInUserModel.Jwt);
            await messageService.ShowAsync(msg);
            if (msg.Contains("Success"))
            {
                await navigationService.PopAsync();
            }
            
        }
        private async Task OpenPickerCommand()
        {
            _tagsModel = await tagRepository.GetAllTags();
            foreach (var tag in _tagsModel.Tags)
            {
                if (this.Tags.Any(x => x.Name.Equals(tag.NameEn)))
                {
                    continue;
                }
                this.Tags.Add(new TagModel() { Name = tag.NameEn });
            }
            await navigationService.PushAsync<MultiPickerViewModel, ObservableCollection<TagModel>>(Tags);
        }

        public void SetViewModelParameter(SignInUserModel? parameter)
        {
            SignInUserModel = parameter;
        }
        public void FillingModel()
        {
            this.GameModel.Tags = new List<int>();
            this.GameModel.AgeGroups = new List<string>();
            this.GameModel.NameCs = "testval";
            this.GameModel.RulesCs = "testval";
            if (this.IsQuarter == true)
            {
                this.GameModel.Duration = "<15";
            }
            if (this.IsHalf == true)
            {
                this.GameModel.Duration = "15-30";
            }
            if (this.IsHour == true)
            {
                this.GameModel.Duration = "30-60";
            }
            if (this.IsHourPlus == true)
            {
                this.GameModel.Duration = "60+";
            }
            if (this.IsKids == true)
            {
                this.GameModel.AgeGroups.Add("K");
            }
            if (this.IsSchool == true)
            {
                this.GameModel.AgeGroups.Add("S");
            }
            if (this.IsTeen == true)
            {
                this.GameModel.AgeGroups.Add("T");
            }
            if (this.IsAdult == true)
            {
                this.GameModel.AgeGroups.Add("A");
            }

            foreach (var tag in Tags)
            {
                if (tag.IsSelected)
                {
                    var foundTag = _tagsModel.Tags.Find(x => x.NameEn.Equals(tag.Name));
                    if (foundTag != null)
                    {
                        this.GameModel.Tags.Add((int)foundTag.Id);
                    }
                }
            }
        }

    }
}
