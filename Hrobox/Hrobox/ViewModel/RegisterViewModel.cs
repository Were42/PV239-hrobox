using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Repository;
using Hrobox.Services.Interfaces;

namespace Hrobox.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public UserModel User { get; set; }

        private ICommand registerCommand;

        public ICommand RegisterCommand => registerCommand;
        private readonly INavigationService navigationService;
        public IUserRepository UserRepository { get; set; }

        public RegisterViewModel(INavigationService navigationService, IUserRepository userRepository)
        {
            this.navigationService = navigationService;
            this.User = new UserModel();
            this.UserRepository = userRepository;
            registerCommand = new AsyncCommand(Register, null, null, false);
        }

        private async Task Register()
        {
            await UserRepository.CreateUser(User);
        }
    }
}