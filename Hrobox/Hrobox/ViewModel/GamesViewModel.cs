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
        public string KeyWord { get; set; } = "";
        private ICommand find;
        public ICommand Find { get { return find; } }

        public GamesViewModel()
        {
            find = new DelegateCommand(FindIt);
        }
        public void FindIt()
        {
            Console.WriteLine("HI");
        }
    }
}
