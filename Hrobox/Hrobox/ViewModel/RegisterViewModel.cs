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

        public ICommand RegisterCommand { get; set; }
        private readonly INavigationService _navigationService;
        public IUserRepository UserRepository { get; set; }

        public RegisterViewModel(INavigationService navigationService, IUserRepository userRepository)
        {
            this._navigationService = navigationService;
            this.User = new UserModel();
            this.UserRepository = userRepository;
            RegisterCommand = new AsyncCommand(Register, null, null, false);
        }

        private async Task Register()
        {
            await UserRepository.CreateUser(User);
        }
    }
}