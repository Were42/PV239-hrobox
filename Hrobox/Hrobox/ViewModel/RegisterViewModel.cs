using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Hrobox.Model;
using IOS_BP_APP.Models;

namespace Hrobox.ViewModel
{
    internal class RegisterViewModel
    {
        public UserModel User { get; set; }

        private ICommand registerCommand;

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            this.User = new UserModel();
            registerCommand = new DelegateCommand(Register);
        }

        private void Register()
        {
            throw new NotImplementedException();
        }
    }
}
