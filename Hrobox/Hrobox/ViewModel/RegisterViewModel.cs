using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public UserModel User { get; set; }

        private ICommand registerCommand;

        public ICommand RegisterCommand { get; }
        private readonly INavigationService navigationService;

        public RegisterViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.User = new UserModel();
            registerCommand = new DelegateCommand(Register);
        }

        private void Register()
        {
        }
    }
}
