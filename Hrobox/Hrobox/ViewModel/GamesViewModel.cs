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
        public ObservableCollection<GameModel> Games { get; set; }
        public ObservableCollection<TagModel> Tags { get; set; } = new ObservableCollection<TagModel>();
        public bool IsQuarter { get; set; }
        public bool IsHalf { get; set; }
        public bool IsHour { get; set; }
        public bool IsAll { get; set; } = true;

        public string KeyWord { get; set; } = "";
        private ICommand find;
        public ICommand Find => find;

        public GamesViewModel()
        {
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
            find = new DelegateCommand(FindIt);
        }
        public void FindIt()
        {
            Console.WriteLine("HI");
        }
    }
}
