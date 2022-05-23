using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Repository;
using Hrobox.Services.Interfaces;
using Hrobox.ViewModel.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hrobox.ViewModel
{
    public class LoginViewModel : ViewModelBase, IViewModel<SignInUserModel>
    {
        public UserLoginModel User { get; set; }
        public SignInUserModel SignedUser { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;
        public LoginViewModel(IUserRepository userRepository, INavigationService navigationService)
        {
            this._userRepository = userRepository;
            this._navigationService = navigationService;
            this.User = new UserLoginModel();
            this.LoginCommand = new AsyncCommand(Login,null,null,false);
            this.RegisterCommand = new AsyncCommand(RegisterFunction, null, null, false);
        }

        private async Task Login()
        {
            var loggedInUser = await _userRepository.SignIn(User);
            if (loggedInUser != null)
            {
                await SecureStorage.SetAsync("bearer", loggedInUser.Jwt);
                SignedUser.Jwt = loggedInUser.Jwt;
                SignedUser.Lang = loggedInUser.Lang;
                SignedUser.Role = loggedInUser.Role;
                await _navigationService.PopAsync();
            }
        }
        private async Task RegisterFunction()
        {
            await _navigationService.PushAsync<RegisterViewModel>();
        }

        public void SetViewModelParameter(SignInUserModel? parameter)
        {
            SignedUser = parameter;
        }
    }
}
