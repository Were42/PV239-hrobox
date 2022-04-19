using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Hrobox.Model;
using IOS_BP_APP.Models;
using Xamarin.Forms;

namespace Hrobox.ViewModel
{
    internal class LoginViewModel
    {
        public UserModel User { get; set; }
        private ICommand loginCommand;
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            this.User = new UserModel();
            this.loginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            throw new NotImplementedException();
        }
    }
}
