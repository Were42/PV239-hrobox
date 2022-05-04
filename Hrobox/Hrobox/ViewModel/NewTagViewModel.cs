using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using Hrobox.ViewModel.Interfaces;

namespace Hrobox.ViewModel
{
    public class NewTagViewModel : ViewModelBase, IViewModel<SignInUserModel>
    {
        public string Tag { get; set; }
        public SignInUserModel SignInUserModel { get; set; }
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

        public void SetViewModelParameter(SignInUserModel? parameter)
        {
            SignInUserModel = parameter;
        }
    }

}
