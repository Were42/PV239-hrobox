using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    public class NewTagViewModel : ViewModelBase
    {
        public string Tag { get; set; }

        private ICommand createTag;
        public ICommand CreateTag { get; }
        private readonly INavigationService navigationService;

        public NewTagViewModel(INavigationService navigationService)

        {
            this.createTag = new DelegateCommand(CreateTagCommand);
        }

        private void CreateTagCommand()
        {
            throw new NotImplementedException();
        }
    }

}
