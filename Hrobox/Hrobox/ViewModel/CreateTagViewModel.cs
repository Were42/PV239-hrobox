using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Hrobox.Model;
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    internal class CreateTagViewModel : ViewModelBase
    {
        public string Tag { get; set; }

        private ICommand createTag;
        public ICommand CreateTag { get; }

        public CreateTagViewModel()
        {
            this.createTag = new DelegateCommand(CreateTagCommand);
        }

        private void CreateTagCommand()
        {
            throw new NotImplementedException();
        }
    }

}
