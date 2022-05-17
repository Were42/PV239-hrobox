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
using Xamarin.Forms;

namespace Hrobox.ViewModel
{
    public class LoginViewModel : ViewModelBase, IViewModel<SignInUserModel>
    {
        public UserLoginModel User { get; set; }
        public SignInUserModel SignedUser { get; set; }
        private ICommand loginCommand;
        public ICommand LoginCommand => loginCommand;

        private ICommand register;
        public ICommand Register => register;
        private readonly INavigationService navigationService;
        private readonly IUserRepository userRepository;
        public LoginViewModel(IUserRepository userRepository, INavigationService navigationService)
        {
            this.userRepository = userRepository;
            this.navigationService = navigationService;
            this.User = new UserLoginModel();
            this.loginCommand = new AsyncCommand(Login,null,null,false);
            this.register = new AsyncCommand(RegisterFunction, null, null, false);
        }

        private async Task Login()
        {
            var loggedInUser = await userRepository.SignIn(User);
            if (loggedInUser != null)
            {
                SignedUser.jwt = loggedInUser.jwt;
                SignedUser.lang = loggedInUser.lang;
                SignedUser.role = loggedInUser.role;
                await navigationService.PopAsync();
            }
        }
        private async Task RegisterFunction()
        {
            await navigationService.PushAsync<RegisterViewModel>();
        }

        public void SetViewModelParameter(SignInUserModel? parameter)
        {
            SignedUser = parameter;
        }
    }
}
