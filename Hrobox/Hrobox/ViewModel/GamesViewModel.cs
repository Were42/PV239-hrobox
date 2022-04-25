using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Model;
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    internal class GamesViewModel : ViewModelBase
    {
        public ObservableCollection<GameModel> Games { get; set; } = new ObservableCollection<GameModel>();
        public ObservableCollection<TagModel> Tags { get; set; } = new ObservableCollection<TagModel>();
        public bool IsQuarter { get; set; }
        public bool IsHalf { get; set; }
        public bool IsHour { get; set; }
        public bool IsAll { get; set; } = true;
        public bool IsKids { get; set; }
        public bool IsSchool { get; set; }
        public bool IsTeen { get; set; }
        public bool IsAdult { get; set; }

        public string KeyWord { get; set; } = "";
        private ICommand find;
        public ICommand Find => find;

        public GamesViewModel()
        {
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
            find = new DelegateCommand(FindIt);
        }
        public void FindIt()
        {
            Console.WriteLine("HI");
        }
    }
}
