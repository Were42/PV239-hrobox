using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using Xamarin.Forms;

namespace Hrobox.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public UserModel User { get; set; }
        private ICommand loginCommand;
        public ICommand LoginCommand { get; }

        private ICommand register;
        public ICommand Register => register;
        private readonly INavigationService navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.User = new UserModel();
            this.loginCommand = new DelegateCommand(Login);
            this.register = new AsyncCommand(RegisterFunction, null, null, false);
        }

        private void Login()
        {
            throw new NotImplementedException();
        }
        private async Task RegisterFunction()
        {
            await navigationService.PushAsync<RegisterViewModel>();
        }
    }
}
